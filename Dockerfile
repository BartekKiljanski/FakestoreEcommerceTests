FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy

RUN apt-get update \
    && apt-get install -y --no-install-recommends wget gnupg ca-certificates \
    && wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | gpg --dearmor -o /usr/share/keyrings/google-linux-signing-keyring.gpg \
    && echo "deb [arch=amd64 signed-by=/usr/share/keyrings/google-linux-signing-keyring.gpg] http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google-chrome.list \
    && apt-get update \
    && apt-get install -y --no-install-recommends google-chrome-stable \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /tests

COPY FakestoreEcommerceTests.sln ./
COPY FakestoreEcommerceTests.csproj ./
RUN dotnet restore FakestoreEcommerceTests.sln

COPY . .

ENV HEADLESS=true

CMD ["dotnet", "test", "FakestoreEcommerceTests.sln"]

