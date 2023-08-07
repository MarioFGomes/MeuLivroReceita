# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file to the working directory
COPY *.csproj ./

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish -c Release -o out --no-restore

# Use a lightweight image for the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /app/out ./

# Expose the port that the application will listen on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "MeuLivroDeReceitas.API.dll"]
