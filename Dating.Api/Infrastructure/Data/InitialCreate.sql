CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "AppUsers" (
    "Id" TEXT NOT NULL CONSTRAINT "PK_AppUsers" PRIMARY KEY,
    "DisplayName" TEXT NOT NULL,
    "Email" TEXT NOT NULL
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20261025142651_InitialCreate', '10.0.13');

COMMIT;

