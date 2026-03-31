# com.mc.core

Core architecture framework for Unity projects.

Provides:

- Dependency injection bootstrap
- LifetimeScope integration
- Base project structure helpers
- Editor-safe initialization utilities

---

## Requirements

This package depends on **VContainer**:

https://github.com/hadashiA/VContainer

If not installed, it will be automatically installed when importing this package.

Manual install (optional):

https://github.com/hadashiA/VContainer.git?path=/VContainer/Assets/VContainer

---

## Installation

Install via Git:

https://github.com/moretech1402/my-unity-packages.git?path=/Packages/com.mc.core

---

## Usage

Create a scene root:

Register dependencies inside your custom scope:
CoreLifetimeScope

```csharp
protected override void Configure(IContainerBuilder builder)
{
    builder.Register<MyService>(Lifetime.Singleton);
}
```

Notes

This package is part of the MC modular Unity framework ecosystem.
