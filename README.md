# CSCE 361 Voting System

This is the repository for Group 7's final project, for the Spring 2026
semester of CSCE 361.

## Setup guide

Required software:

- .NET 10.0
- MS SQL Server 2022. 
- NPM 11 or higher
- Vite 8 or higher

An automated install script for Ubuntu 24.04 is included as a tested environment.

# MS SQL Configuration

**PLEASE READ**: If you're not using the install script, you will
need to run the SQL scripts in the `sql` folder to populate the database. First run
`VotingSystemDatabaseCreation.sql`, and then run `VotingSystemTestData.sql`. Also,
the admin username for the SQL database MUST be `sa`, and the password MUST be 
`Charter9 Untapped Carnivore`. These credentials are hardcoded into the .NET server and
if they differ from the SQL server's actual credentials, the database connection will fail.

### Windows

Windows users should use WSL to run an Ubuntu VM on their device. Afterwards, they
should follow the Linux steps.

To install WSL, open a terminal window and run:

```
wsl --install
```

You'll then need to reboot your computer. After the reboot, you can install Ubuntu
on top of WSL with this command:

```
wsl --install Ubuntu-24.04
```

Follow the prompt to set a username and password, and it should drop you into an Ubuntu
session. To reenter Ubuntu from a standard Windows command line, simply run `wsl`.
Now, to install the program, follow the steps below while in your Ubuntu environment.

### Linux

# PLEASE READ: THIS PROGRAM WILL ONLY WORK ON BARE METAL OR ON VIRTUAL MACHINES THAT SHARE AN IP WITH THE HOST (e.g. WSL)

Before running the script, please make sure all of your packages are up to date!

```bash
sudo apt update
sudo apt upgrade
```

Please reboot your system if there were any package updates.

To run the script,

1. Download `install.sh`.

```bash
wget https://raw.githubusercontent.com/aslmacnabb/votingsystemgroup7/refs/heads/main/install.sh
```

2. Mark the script as executable:

```bash
chmod +x install.sh
```

3. Run the script, and enter your root password when necessary.

```bash
./install.sh
```

# How to run the program

1. Ensure MS SQL Server is running after supplying it with data by running the
[necessary scripts](https://github.com/aslmacnabb/votingsystemgroup7#setup-guide).

2. Run the server component.

```bash
cd server
dotnet run
```

3. In a separate terminal window, run the client component

```bash
cd client
npm install -D vite
npm run dev
```

4. Navigate to [http://localhost:5173](http://localhost:5173) in a browser.
To test admin functionality, use username `admin` and password `admin`.
To test voter functionality, use username `Bob` and password `Burger`.

## SQL credentials

USER USERNAME: HUSKERS 

PASSWORD: CORN

ADMIN USERNAME: sa

ADMIN PASSWORD: Charter9 Untapped Carnivore
