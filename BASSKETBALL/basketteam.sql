-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Nov 18. 10:51
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `basketteam`
--
CREATE DATABASE IF NOT EXISTS `basketteam` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `basketteam`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `matchdata`
--

CREATE TABLE `matchdata` (
  `id` varchar(36) COLLATE utf8_hungarian_ci NOT NULL,
  `be` datetime NOT NULL,
  `ki` datetime NOT NULL,
  `try` int(11) NOT NULL,
  `goal` int(11) NOT NULL,
  `fault` int(11) NOT NULL,
  `createdtime` datetime NOT NULL,
  `updatedtime` datetime NOT NULL,
  `playerId` varchar(36) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `matchdata`
--

INSERT INTO `matchdata` (`id`, `be`, `ki`, `try`, `goal`, `fault`, `createdtime`, `updatedtime`, `playerId`) VALUES
('4230a460-bc4c-41d7-9717-15a89a112b73', '2024-11-18 08:31:59', '2024-11-18 09:31:59', 6, 2, 4, '2024-11-18 09:15:08', '2024-11-18 09:32:22', '458189a8-b95a-4d9b-bba7-8ea73a73d5a1'),
('ce9c9eab-b1a1-4724-95bb-41a15cc1737f', '2024-11-18 08:37:43', '2024-11-18 08:37:43', 0, 0, 0, '2024-11-18 09:37:50', '2024-11-18 09:37:50', '14d04cf7-3586-4628-b4c5-01bb88587ee5');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `player`
--

CREATE TABLE `player` (
  `id` varchar(36) COLLATE utf8_hungarian_ci NOT NULL,
  `name` varchar(37) COLLATE utf8_hungarian_ci NOT NULL,
  `height` int(11) NOT NULL,
  `weight` int(11) NOT NULL,
  `createdTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `player`
--

INSERT INTO `player` (`id`, `name`, `height`, `weight`, `createdTime`) VALUES
('14d04cf7-3586-4628-b4c5-01bb88587ee5', 'Magdi anyus', 156, 290, '2024-11-18 08:33:11'),
('458189a8-b95a-4d9b-bba7-8ea73a73d5a1', 'Sándor Aladár', 167, 65, '2024-11-18 08:26:24');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `matchdata`
--
ALTER TABLE `matchdata`
  ADD PRIMARY KEY (`id`),
  ADD KEY `playerId` (`playerId`);

--
-- A tábla indexei `player`
--
ALTER TABLE `player`
  ADD PRIMARY KEY (`id`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `matchdata`
--
ALTER TABLE `matchdata`
  ADD CONSTRAINT `matchdata_ibfk_1` FOREIGN KEY (`playerId`) REFERENCES `player` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
