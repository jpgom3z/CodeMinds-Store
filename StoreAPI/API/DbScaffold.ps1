# Comando para PM console: .\API\DbScaffold.ps1
Scaffold-DbContext "Name=StoreDB" Microsoft.EntityFrameworkCore.SqlServer -Context StoreDB -ContextDir Data -OutputDir Data\Models -Force -NoPluralize