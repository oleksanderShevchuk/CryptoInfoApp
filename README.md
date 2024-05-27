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
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/1ad09c43-3ec1-483a-af13-6f4e0673a49b)
*The home page displays the top 10 cryptocurrencies.*

### Details Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/3fd0b267-26d1-474e-a015-9e91f6b84d93)
*The details page shows comprehensive information about a selected cryptocurrency, including price, volume, market details, and a Japanese candlestick chart.*

### Coins Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/8713879a-1948-4348-b294-d381bd39e120)
*The page with all Coins and the search to find specific cryptocurrencies by name or code.*

### Converter Page
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/14fb4d18-933d-4384-816c-9d013cce0db3)
*The currency converter page allows you to convert one cryptocurrency to another.*

### Dark Theme
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/333e6280-d62d-48d1-b54b-0ce751131f5a)
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/dd155c30-73c4-4992-9aec-8f472ec3de80)
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/f4d17cd4-37ec-4d6f-9085-23c5e6c04071)
![image](https://github.com/oleksanderShevchuk/CryptoInfoApp/assets/88186733/1c751ed4-f806-406c-afeb-20af9792b217)
*The application in dark theme.*

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
