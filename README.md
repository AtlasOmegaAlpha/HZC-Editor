# HZC Editor
Collision editor and mesh exporter/importer for HZC files (found in NDS and
3DS games developed using Firebrand Games' Octane Engine).

Currently, the program only has support for v1.3 HZC files, like the ones
used in Cartoon Network Racing DS and Ferrari Challenge: Trofeo Pirelli DS.

![Program Preview](https://i.imgur.com/5EDsCfz.png)

## Features
- Open, save and create new `.hzc` files
- Edit the collision models' vertex data, grid and custom attributes
- Import and export collision as OBJ
- Recompute the collision mesh's normals
- Rebuild the collision grid from the geometry
- Add/remove custom attributes and assign them to triangles
- [3D Viewer](#hzc-viewer) included to preview the collision model, grid,
attributes and triangle details with different color modes

## Building
Requirements:
- [.NET SDK 8.0](https://dotnet.microsoft.com/download) or newer.
- Only Windows is supported.

```sh
dotnet build "HZC Editor.slnx" -c Release
```

The build automatically copies the viewer from the `Viewer` directory next to
the editor. If `Viewer/HZCViewer.exe` is missing, the editor still builds
and runs normally, but you won't be able to preview HZC files in 3D.

## HZC Viewer
The HZC Viewer program is a separate OpenGL 3D viewer that renders the collision
mesh with attribute coloring, and also supports viewing the collision grid and
inspecting the mesh's triangles and attributes.

HZC Viewer is a separate, closed-source program created from my internal
Lumel Engine 3D Viewer Library. You can also run the viewer on its own or
drag `.hzc` files onto it.

## License
HZC Editor is released under the [MIT License](LICENSE). The HZC Viewer and
its third-party components come with their own licenses.