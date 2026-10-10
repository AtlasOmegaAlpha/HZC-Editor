using Horizon;
using System.Diagnostics;

namespace HZC_Editor
{
    public static class ViewerLauncher
    {
        public const string VIEWER_DIRECTORY = "Viewer";
        public const string VIEWER_EXECUTABLE = "HZCViewer.exe";

        public static string GetViewerPath()
        {
            return Path.Combine(AppContext.BaseDirectory, VIEWER_DIRECTORY, VIEWER_EXECUTABLE);
        }

        public static bool IsAvailable()
        {
            return File.Exists(GetViewerPath());
        }

        static readonly string TempRoot = Path.Combine(Path.GetTempPath(), "HZC Editor");
        static readonly string SessionTempDir = Path.Combine(TempRoot, $"viewer-{Environment.ProcessId}");
        static bool _cleanupRegistered = false;

        public static Process Launch(HZC hzc, string? path)
        {
            string viewerPath = GetViewerPath();
            if (!File.Exists(viewerPath))
                throw new FileNotFoundException("The HZC Viewer executable was not found. Please reinstall the program.", viewerPath);

            RegisterCleanup();
            string snapshot = WriteSnapshot(hzc, path);

            ProcessStartInfo info = new ProcessStartInfo(viewerPath)
            {
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(viewerPath)
            };

            info.ArgumentList.Add(snapshot);
            return Process.Start(info) ?? throw new InvalidOperationException("The viewer process could not be started.");
        }

        static string WriteSnapshot(HZC hzc, string? path)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                using EndianWriter writer = new EndianWriter(stream, Endianness.LittleEndian);
                hzc.Write(writer);
                data = stream.ToArray();
            }

            string dir = Path.Combine(SessionTempDir, Guid.NewGuid().ToString("N")[..8]);
            Directory.CreateDirectory(dir);

            string name = string.IsNullOrWhiteSpace(path) ? "Untitled.hzc" : Path.GetFileName(path);
            string combPath = Path.Combine(dir, name);
            File.WriteAllBytes(combPath, data);
            return combPath;
        }

        static void RegisterCleanup()
        {
            if (_cleanupRegistered)
                return;

            _cleanupRegistered = true;
            CleanSessions();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        static void OnProcessExit(object? sender, EventArgs e)
        {
            TryDelete(SessionTempDir);
        }

        static void CleanSessions()
        {
            try
            {
                if (!Directory.Exists(TempRoot))
                    return;

                foreach (string dir in Directory.GetDirectories(TempRoot, "viewer-*"))
                {
                    if (dir != SessionTempDir && Directory.GetLastWriteTimeUtc(dir) < DateTime.UtcNow.AddDays(-1))
                        TryDelete(dir);
                }
            }
            catch { }
        }

        static void TryDelete(string dir)
        {
            try
            {
                if (Directory.Exists(dir))
                    Directory.Delete(dir, true);
            }
            catch { }
        }
    }
}
