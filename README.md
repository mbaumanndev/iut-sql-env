Cours de SQL
============

Ce dépôt contient du contenu déstiné à une utilisation pédagogique auprès des étudiants de seconde année du département informatique de l'IUT d'Amiens suivant le parcours orienté en bases de données.

Pré-requis
----------

Pour utiliser le contenu de ce dépôt, vous devez avoir un ordinateur équipé de :

- Docker 17.09.0+
- Docker Compose

Autres outils
-------------

Vous pouvez utiliser [Azure Data Studio](https://docs.microsoft.com/fr-fr/sql/azure-data-studio/download?view=sql-server-ver15), ou [Visual Studio Code](https://code.visualstudio.com/) avec un [plugin pour MSSQL](https://docs.microsoft.com/fr-fr/sql/visual-studio-code/sql-server-develop-use-vscode?view=sql-server-ver15). Si vous êtes sous Windows, vous pouvez également utiliser [Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017) afin d'interagir avec le serveur SQL lancé dans notre environement docker.

Lancement de Docker
-------------------

Pour ce nouveau projet, nous allons de nouveau utiliser Docker avec l'utilitaire docker-compose. Notre infrastructure comporte deux conteneurs :
- Un conteneur Microsoft SQL Server en mode base de données,
- Un conteneur Microsoft SQL Server qui nous servira à avoir la ligne de commande `sqlcmd`,

> SQL Serveur nécessite d'être authentifié. Les identifiants sont les suivants :
>
> - Login : `sa`
> - Pass  : `Amiens2020!`

Afin de démarrer notre infrastructure, nous allons éxécuter la commande suivante :

```
docker-compose up -d
```

Une fois l'infrastructure démarrée, vous pouvez vous pouvez ouvrir la ligne de commande avec la commande suivante :

```
docker-compose run sqlcmd
```

En fin de séance, n'oubliez pas d'éteindre l'infrastructure avec la commande appropriée :

```
docker-compose down
```

Cours sur les ORMs
------------------

```
dotnet tool install --global dotnet-ef --version 3.1.1
cd src/IutInfo.BddAvance.CoursOrm
dotnet restore
dotnet run
```

Talend
------

```
/opt/talend/TOS_BD-linux-gtk-x86_64 -vm "/usr/lib/jvm/java-8-oracle/bin"
```

Générateur de données
---------------------

```
dotnet run --project src/IutInfo.BddAvance.FakeDataGenerator
```
