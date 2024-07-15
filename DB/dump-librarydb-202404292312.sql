-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)--
--
-- Host: localhost    Database: librarydb
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240427175713_InitMig','6.0.29'),('20240427180506_InitMig1','6.0.29');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authors`
--

DROP TABLE IF EXISTS `authors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authors` (
  `AuthorId` int NOT NULL AUTO_INCREMENT,
  `AuthorName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AuthorBio` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`AuthorId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authors`
--

LOCK TABLES `authors` WRITE;
/*!40000 ALTER TABLE `authors` DISABLE KEYS */;
INSERT INTO `authors` VALUES (1,'Tasnif Taussuk','Solid Guy'),(2,'Issac Asimov','Good guy');
/*!40000 ALTER TABLE `authors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `BookId` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PublishedDate` datetime(6) NOT NULL,
  `ISBN` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `AuthorID` int NOT NULL,
  `AvailableCopies` int NOT NULL,
  `TotalCopies` int NOT NULL,
  PRIMARY KEY (`BookId`),
  KEY `IX_Books_AuthorID` (`AuthorID`),
  CONSTRAINT `FK_Books_Authors_AuthorID` FOREIGN KEY (`AuthorID`) REFERENCES `authors` (`AuthorId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Lord of the Rings','1990-04-27 18:02:06.416000','234KMNJDFU79DFS89',1,15,15),(2,'Foundation','1992-04-28 19:52:35.671000','879DSG76DFGS8DS',2,10,10);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `borrowedbooks`
--

DROP TABLE IF EXISTS `borrowedbooks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `borrowedbooks` (
  `BorrowID` int NOT NULL AUTO_INCREMENT,
  `BorrowDate` datetime(6) NOT NULL,
  `ReturnDate` datetime(6) NOT NULL,
  `MemberId` int NOT NULL,
  `BookId` int NOT NULL,
  `Status` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`BorrowID`),
  KEY `IX_BorrowedBooks_BookId` (`BookId`),
  KEY `IX_BorrowedBooks_MemberId` (`MemberId`),
  CONSTRAINT `FK_BorrowedBooks_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `books` (`BookId`) ON DELETE CASCADE,
  CONSTRAINT `FK_BorrowedBooks_Members_MemberId` FOREIGN KEY (`MemberId`) REFERENCES `members` (`MemberId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrowedbooks`
--

LOCK TABLES `borrowedbooks` WRITE;
/*!40000 ALTER TABLE `borrowedbooks` DISABLE KEYS */;
INSERT INTO `borrowedbooks` VALUES (1,'2024-04-27 18:36:45.391000','2024-04-29 03:50:52.037514',1,1,'Returned'),(2,'2024-04-27 18:39:38.861000','2024-04-29 03:51:27.448000',1,1,'Returned'),(3,'2024-04-27 20:33:42.831000','2024-04-29 04:21:26.887027',1,1,'Returned'),(5,'2024-04-29 04:04:27.413801','2024-04-29 04:05:04.758789',1,2,'Returned'),(6,'2024-04-29 04:12:12.616870','2024-04-29 04:12:25.746958',1,2,'Returned'),(7,'2024-04-29 04:12:44.117404','2024-04-29 04:12:59.406418',1,2,'Returned'),(8,'2024-04-29 04:13:30.748260','2024-04-29 04:13:35.370782',1,2,'Returned'),(9,'2024-04-29 04:15:47.513308','2024-04-29 04:20:19.461486',1,2,'Returned'),(10,'2024-04-29 04:21:09.256958','2024-04-29 04:21:52.732954',1,2,'Returned'),(11,'2024-04-29 04:21:15.496895','2024-04-29 04:21:43.127990',1,1,'Returned'),(12,'2024-04-29 04:24:59.289980','2024-04-29 04:25:01.913922',1,1,'Returned'),(13,'2024-04-29 04:26:16.990741','2024-04-29 04:26:27.659417',1,2,'Returned'),(22,'2024-04-29 17:33:13.478212','2024-04-29 17:38:10.000871',1,1,'Returned'),(23,'2024-04-29 17:37:47.486303','2024-04-29 17:37:57.414895',1,2,'Returned'),(28,'2024-04-29 17:42:09.914657','2024-04-29 17:50:05.412216',1,1,'Returned'),(29,'2024-04-29 17:42:38.880705','2024-04-29 17:49:30.675664',1,2,'Returned'),(30,'2024-04-29 17:42:42.054400','2024-04-29 17:49:47.750399',1,2,'Returned');
/*!40000 ALTER TABLE `borrowedbooks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `members`
--

DROP TABLE IF EXISTS `members`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `members` (
  `MemberId` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RegistrationDate` datetime(6) NOT NULL,
  PRIMARY KEY (`MemberId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `members`
--

LOCK TABLES `members` WRITE;
/*!40000 ALTER TABLE `members` DISABLE KEYS */;
INSERT INTO `members` VALUES (1,'John','Doe','j.doe@gmail.com','01676386289','1234','2024-04-27 18:05:51.395000');
/*!40000 ALTER TABLE `members` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'librarydb'
--
/*!50003 DROP PROCEDURE IF EXISTS `getbookdetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `getbookdetails`()
begin
	select BookId,	
		Title,
		AuthorName,	
		PublishedDate,	
		ISBN,	
		case when AvailableCopies > 0 then 'Y' else 'N' end  AvailableCopies
	from books b 
	inner join authors a 
	where B.AuthorID = A.AuthorId;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-04-29 23:12:46
