# CSCE 361 Voting System

This is the repository for Group 7's final project, for the Spring 2026
semester of CSCE 361.

## Setup guide

This software should run on anything with .NET 10, MS SQL Server, a recent
version of NPM, and Vite installed. An automated install script for Ubuntu 24.04
is included as a tested environment.

### Windows

Windows users should use WSL to run an Ubuntu VM on their device. Afterwards, they
should follow the Linux steps.

To install Ubuntu through WSL, open a terminal window and run:

```
wsl --install  Ubuntu-24.04
```

Once the setup process is complete, you can search for Ubuntu in your start menu.

### Linux

Before running the script, please make sure all of your packages are up to date!

```bash
sudo apt update
sudo apt upgrade
```

Please reboot your system if there were any package updates.

To run the script,

1. Download `install.sh`.
2. Mark the script as executable:

```bash
chmod +x install.sh
```

3. Run the script, and enter your root password when necessary.

```bash
./install.sh
```

4. To run the server component:

```bash
cd ~/votingsystemgroup7/server
dotnet run
```

5. To run the client component:

```bash
cd ~/votingsystemgroup7/client
npm run dev
```

## SQL credentials

USER USERNAME: HUSKERS 

PASSWORD: CORN

ADMIN USERNAME: sa

ADMIN PASSWORD: Charter9 Untapped Carnivore
