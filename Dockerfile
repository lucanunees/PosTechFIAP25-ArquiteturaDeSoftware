# Use Ubuntu 22.04 as the base image
FROM ubuntu:22.04

# Set environment variables for SQL Server
ENV ACCEPT_EULA=Y \
    MSSQL_PID=Express \
    DEBIAN_FRONTEND=noninteractive

# Switch to root user
USER root

# Install dependencies and SQL Server 2019
RUN apt-get update && apt-get install -y curl apt-transport-https gnupg && \
    curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > /usr/share/keyrings/microsoft.gpg && \
    echo "deb [arch=amd64 signed-by=/usr/share/keyrings/microsoft.gpg] https://packages.microsoft.com/ubuntu/20.04/mssql-server-2019 focal main" > /etc/apt/sources.list.d/mssql-server.list && \
    apt-get update && apt-get install -y mssql-server && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Install sqlcmd and other tools
RUN apt-get update && apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc && \
    apt-get clean && rm -rf /var/lib/apt/lists/*

# Expose the default SQL Server port
EXPOSE 1433

# Copy the migration scripts into the container
COPY ./src/FiapCloudGames.Infrastructure/Migrations /migrations

# Run the SQL Server and apply migrations
CMD ["/bin/bash", "-c", "/opt/mssql/bin/sqlservr & sleep 20 && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $SA_PASSWORD -i /migrations/ApplyMigrations.sql"]