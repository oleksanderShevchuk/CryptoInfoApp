# Crypto Information Application

## Overview

This repository contains a C# application built using the .NET platform and WPF technologies to display various information related to cryptocurrencies. The application fetches data from open API such as CoinGecko, and provides a user-friendly interface to view and interact with cryptocurrency data.

## Features

- Multi-page application with navigation.
- The main page displays the top 10 cryptocurrencies returned by the API.
- Detailed currency information page with data on price, volume, price change, and available markets with links to market pages.
- Currency search functionality by name or code.
- MVVM architecture for clean code and separation of concerns.
- Aesthetic UI design with optional light/dark theme support.
- Displaying quote charts for currencies (Japanese candlestick chart).
- Currency conversion page.

## APIs Used

- [CoinGecko API](https://www.coingecko.com/en/api/documentation)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/oleksanderShevchuk/CryptoInfoApp.git
    ```
2. Navigate to the project directory:
    ```bash
    cd CryptoInfoApp
    ```
3. Open the solution file in Visual Studio:
    ```bash
    CryptoInfoApp.sln
    ```

## Usage

1. Build and run the application using Visual Studio.
2. Use the main navigation to explore different pages of the application:
   - **Home**: View the top N cryptocurrencies.
   - **Details**: Click on a cryptocurrency to view detailed information.
   - **Search**: Search for cryptocurrencies by name or code.
   - **Converter**: Convert one cryptocurrency to another.
3. Switch between light and dark themes from the settings menu.

## Screenshots

Here are some screenshots of the application to give you a quick look at what to expect:

### Home Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/2da69a5c-f959-4e9b-bbaa-7c923fcea329)
*The home page displays the top 10 cryptocurrencies.*

### Details Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/b8249a99-3076-4e88-a8d0-7196b7d832e9)
*The details page shows comprehensive information about a selected cryptocurrency, including price, volume, market details, and a Japanese candlestick chart.*

### Coins Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/f17f2c75-ea02-4cbf-9f2a-42d1cd02c7c4)
*The page with all Coins and the search to find specific cryptocurrencies by name or code.*

### Converter Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/2c25403d-9068-41e1-82d7-177d0d55c5a0)
*The currency converter page allows you to convert one cryptocurrency to another.*

### Light Theme
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/22b24b8a-d77b-4526-93b9-f3dae822ca06)
*The application in light theme.*

### Dark Theme
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/da2f95d0-2a55-497e-a79f-65af68e30491)
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/418efc03-cde3-4e31-9fcf-8029e79bf046)
*The application in dark theme.*

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
