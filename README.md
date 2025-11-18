# pet-tracker-api

---

¡Bienvenido al repositorio del proyecto! Este es el repositorio dedicado al backend en **.NET**. A continuación, encontrarás las instrucciones para configurar y ejecutar el servidor.
---

## 🛠️ **Configuración del Servidor (.NET)**

Sigue estos pasos para configurarlo y ejecutarlo por primera vez.

### **1️⃣ Requisitos previos**

- [.NET SDK 8.0](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) instalado.

### **2️⃣ Pasos para iniciar el servidor**


1. **Instala las dependencias del proyecto**
   ```bash
   dotnet restore
   ```
2. **Corre las migraciones de la base de datos**
   ```bash
   dotnet ef database update
   ```
3. **Inicia el servidor**
```bash
dotnet run
```

### 🌐 **Ruta por defecto de la API**

Una vez que el servidor esté en ejecución, la API estará disponible en:

```
editar la ruta
```

Por defecto, los endpoints estarán bajo la siguiente ruta:

```
editar la ruta
```

### 🚦 **Pruebas**

Para probar que el servidor está funcionando correctamente, puedes usar herramientas como **Postman** o `curl`.