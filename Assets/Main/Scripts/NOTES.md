## UNITY ARKIT PORTAL
[YouTube Tutorial](https://www.youtube.com/watch?v=g78hQB8UKEM&list=PLPCqNOwwN794Gz5fzUSi1p4OqLU0HTmvn&index=1)

* import AR kit
* PACKAGES IMPORT
    1. Multiplayer HLAPI
    2. XR Legacy Input Helpers

* SET OVERALL SETTINGS
    1. DISABLE VULKAN (PROJECT SETTINGS / PLAYER SETTINGS / OTHER SETTINGS)
    2. PLATFORM ANDROID (BUILD SETTINGS)
    3. SET ARCORE USED (PROJECT SETTINGS / PLAYER SETTINGS / XR PREVIEW)
    4. DISABLE INSTANT PREVIEW (PROJECT SETTINGS / COREAR SETTINGS )

* CREATE ARCoreDevice
    1. SET ARCoreSession (Script)
    2. ATTACH SessionConfig
    3. ATTACH CameraConfigFilter

* CREATE ARCoreCamera
    1. ATTACH TrackedPoseDriver
        * SET PoseSource - ColorCamera
        * SET UpdateType - BeforeRender
        * SET RelativeTransform - TRUE
    2. ATTACH ARCoreBackgroundRenderer
        * SET BGMaterial - ARBackground(Material)

* CREATE ARController
    1. SET ARController (CustomScript)

* PORTAL MODELS REQUIRE SHADERS AND STUFF (REFER VIDEO)


