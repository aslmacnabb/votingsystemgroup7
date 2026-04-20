#!/bin/bash

echo "Installing git, docker, and dotnet10"
sudo apt install -y git dotnet10 curl docker.io
git clone https://github.com/aslmacnabb/votingsystemgroup7

# sqlcmd install instructions taken from https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-setup-tools
echo "Installing sqlcmd"
curl -sSL -O https://packages.microsoft.com/config/ubuntu/24.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt update
sudo apt install -y mssql-tools18 unixodbc-dev

# MS SQL install instructions taken from https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-ubuntu
echo "Installing MS SQL Server"
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Charter9 Untapped Carnivore" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

# NPM install instructions taken from https://nodesource.com/products/distributions
echo "Installing node.js, npm, and vite"
cd ~/votingsystemgroup7/client
curl -fsSL https://deb.nodesource.com/setup_24.x | sudo -E bash -
sudo apt install -y nodejs
npm install -D vite


echo "Configuring SQL server"
cd ~/votingsystemgroup7
/opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P 'Charter9 Untapped Carnivore' -No -i sql/VotingSystemDatabaseCreation.sql
/opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P 'Charter9 Untapped Carnivore' -No -i sql/VotingSystemTestData.sql

echo "Disabling firewall"
sudo ufw disable

echo "Voting system installation complete!"
