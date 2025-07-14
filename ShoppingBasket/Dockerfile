# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
# For more information, please see https://aka.ms/containercompat

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy the project files to the container
COPY ["Scripts/apply-migrations.sh", "/app/Scripts/"]
RUN chmod +x /app/Scripts/apply-migrations.sh
COPY ["ShoppingBasket/ShoppingBasket.csproj", "ShoppingBasket/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
# This stage is used to restore the service project dependencies
RUN dotnet restore "ShoppingBasket/ShoppingBasket.csproj"
# Copy the rest of the source code to the container
COPY . .
# This stage is used to build the service project
WORKDIR "/src/ShoppingBasket"
RUN dotnet build "ShoppingBasket.csproj" -c Release -o /app/build
RUN dotnet publish "ShoppingBasket.csproj" -c Release -o /app/publish
# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "ShoppingBasket.csproj" -c Release -o /app/publish
# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingBasket.dll"]