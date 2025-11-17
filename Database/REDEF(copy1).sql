/*
SQLyog Ultimate v10.00 Beta1
MySQL - 5.5.5-10.4.32-MariaDB : Database - acebedo
*********************************************************************
*/


/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`acebedo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;

USE `acebedo`;

/*Table structure for table `patient_data` */

DROP TABLE IF EXISTS `patient_data`;

CREATE TABLE `patient_data` (
  `patientID` int(5) NOT NULL AUTO_INCREMENT,
  `fname` varchar(20) NOT NULL,
  `mname` varchar(20) NOT NULL,
  `lname` varchar(20) NOT NULL,
  `bday` date NOT NULL,
  `region` varchar(50) NOT NULL,
  `province` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `brgy` varchar(50) NOT NULL,
  `street` varchar(100) NOT NULL,
  `diabetic` varchar(10) NOT NULL,
  `highblood` varchar(10) NOT NULL,
  `occupation` varchar(50) DEFAULT NULL,
  `sports` varchar(100) DEFAULT NULL,
  `hobbies` varchar(200) DEFAULT NULL,
  `mobilenum` varchar(13) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `others` varchar(150) DEFAULT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`patientID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `patient_data` */

LOCK TABLES `patient_data` WRITE;

insert  into `patient_data`(`patientID`,`fname`,`mname`,`lname`,`bday`,`region`,`province`,`city`,`brgy`,`street`,`diabetic`,`highblood`,`occupation`,`sports`,`hobbies`,`mobilenum`,`gender`,`others`,`date`) values (1,'Juan','Garcia','Reyes','2004-06-26','Cordillera Administrative Region (CAR)','Benguet','Bakun','Bagu','20-C Sapamanay St.','No','No','Office Worker','Jogging','Reading','+639415500808','Male','N/A','2025-11-12'),(2,'Juan','Navarro','Santos','1981-07-19','Region VII (Central Visayas)','Cebu','Danao City','Masaba','','Yes','No','Office Worker','Jogging','Reading','+639380434361','Male',NULL,'2025-10-16'),(3,'Maria','Bautista','Ramos','1990-02-01','Region X (Northern Mindanao)','Misamis Occidental','Bonifacio','Tusik','','Yes','No','Office Worker','Jogging','Reading','+639571365431','Male',NULL,'2024-12-04'),(4,'Rosa','Lopez','Navarro','2003-04-25','Region IV-A (CALABARZON)','Quezon','Padre Burgos','Walay','','Yes','No','Office Worker','Jogging','Reading','+639461084481','Female',NULL,'2023-08-01'),(5,'Pedro','Lopez','Cruz','1996-07-03','Region IV-A (CALABARZON)','Rizal','City Of Antipolo','Calawis','','No','No','Office Worker','Jogging','Reading','+639223111465','Male',NULL,'2024-07-15'),(6,'Carmen','Torres','Garcia','1985-10-26','Region II (Cagayan Valley)','Isabela','Quezon','Barucboc Norte','','No','No','Office Worker','Jogging','Reading','+639860521254','Female',NULL,'2024-08-27'),(7,'Juan','Lopez','Santos','2005-01-21','National Capital Region (NCR)','City Of Manila','San Nicolas','Barangay 269','','No','No','Office Worker','Jogging','Reading','+639903073182','Male',NULL,'2025-12-30'),(8,'Antonio','Navarro','Lopez','2001-08-16','Region I (Ilocos Region)','La Union','Balaoan','Pa-o','','Yes','No','Office Worker','Jogging','Reading','+639205215544','Male',NULL,'2023-07-26'),(9,'Liza','Bautista','Reyes','1983-09-22','Autonomous Region in Muslim Mindanao (ARMM)','Sulu','Maimbung','Tubig-Samin','','No','No','Office Worker','Jogging','Reading','+639967032773','Female',NULL,'2023-02-14'),(10,'Carmen','Santos','Reyes','1987-10-08','National Capital Region (NCR)','Second District','City Of Mandaluyong','Plainview','Hahahahha','No','No','Office Worker','Jogging','Reading','+639364493600','Male','N/A','2025-11-12'),(11,'Christian Jay','N/A','Almerol','1988-02-20','National Capital Region (NCR)','Second District','City Of Mandaluyong','Plainview','Blk 10 Binondo St.','No','No','N/A','N/A','N/A','+639127264723','Male','N/A','2025-11-13'),(12,'Angelo Royce','N/A','Morales','1999-02-20','National Capital Region (NCR)','Second District','City Of Mandaluyong','Plainview','123 Mabuhay St.','No','Yes','N/A','Basketball','N/A','+639812365347','Other','N/A','2025-11-12');

UNLOCK TABLES;

/*Table structure for table `tbl_appointments` */

DROP TABLE IF EXISTS `tbl_appointments`;

CREATE TABLE `tbl_appointments` (
  `appointmentID` int(11) NOT NULL AUTO_INCREMENT,
  `checkupID` int(11) NOT NULL,
  `patientID` int(11) NOT NULL,
  `patientName` varchar(255) DEFAULT NULL,
  `doctorID` int(11) NOT NULL,
  `doctorName` varchar(255) NOT NULL,
  `appointmentDate` datetime NOT NULL,
  `createdAt` datetime DEFAULT current_timestamp(),
  `AppointmentType` varchar(55) DEFAULT NULL,
  `Reason` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`appointmentID`),
  KEY `patientID` (`patientID`),
  KEY `doctorID` (`doctorID`),
  CONSTRAINT `tbl_appointments_ibfk_1` FOREIGN KEY (`patientID`) REFERENCES `patient_data` (`patientID`),
  CONSTRAINT `tbl_appointments_ibfk_2` FOREIGN KEY (`doctorID`) REFERENCES `tbl_doctor` (`doctorID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_appointments` */

LOCK TABLES `tbl_appointments` WRITE;

insert  into `tbl_appointments`(`appointmentID`,`checkupID`,`patientID`,`patientName`,`doctorID`,`doctorName`,`appointmentDate`,`createdAt`,`AppointmentType`,`Reason`) values (1,8,6,'Carmen Torres Garcia',1,'Ana Dela Santos','2025-11-15 00:00:00','2025-11-13 02:56:12','Regular',NULL),(2,9,12,'Angelo Royce Morales',5,'Miguel Reyes Torres','2025-11-18 00:00:00','2025-11-13 03:01:02','PWD',NULL),(3,13,11,'Christian Jay Almerol',2,'Jose Navarro Bautista','2025-11-16 00:00:00','2025-11-15 04:30:59','Check-up',''),(4,13,11,'Christian Jay Almerol',1,'Ana Dela Santos','2025-11-16 00:00:00','2025-11-15 04:34:30','Check-up','');

UNLOCK TABLES;

/*Table structure for table `tbl_audit_trail` */

DROP TABLE IF EXISTS `tbl_audit_trail`;

CREATE TABLE `tbl_audit_trail` (
  `AuditID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `ActionType` varchar(50) DEFAULT NULL,
  `ActionDetails` text DEFAULT NULL,
  `TableName` varchar(50) DEFAULT NULL,
  `RecordID` int(11) DEFAULT NULL,
  `ActivityTime` time DEFAULT NULL,
  `ActivityDate` date DEFAULT NULL,
  PRIMARY KEY (`AuditID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `tbl_audit_trail_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tbl_users` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=543 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_audit_trail` */

LOCK TABLES `tbl_audit_trail` WRITE;

insert  into `tbl_audit_trail`(`AuditID`,`UserID`,`Username`,`ActionType`,`ActionDetails`,`TableName`,`RecordID`,`ActivityTime`,`ActivityDate`) values (1,1,'sadmin','Login','User logged in',NULL,NULL,'02:03:57','2025-11-07'),(2,1,'sadmin','Update User','Update User: sadmin',NULL,NULL,'02:04:30','2025-11-07'),(3,1,'sadmin','Add Supplier','Added supplier: VisionCare Trading',NULL,NULL,'02:11:16','2025-11-07'),(4,1,'sadmin','Add Supplier','Added supplier: OptiLens Enterprises',NULL,NULL,'02:12:10','2025-11-07'),(5,1,'sadmin','Update Supplier','Updated supplier: Visioncare Trading',NULL,NULL,'02:12:23','2025-11-07'),(6,1,'sadmin','Add Supplier','Added supplier: BrightView Optical Supplies',NULL,NULL,'02:13:13','2025-11-07'),(7,1,'sadmin','Add Supplier','Added supplier: ClearVision Trading Corp.',NULL,NULL,'02:13:54','2025-11-07'),(8,1,'sadmin','Update Supplier','Updated supplier: Brightview Optical Supplies',NULL,NULL,'02:14:01','2025-11-07'),(9,1,'sadmin','Update','Updated patient record:\r\nBirthday: 08/10/1987 ? 1987-10-08\r\nCity: Makati ? Candaba\r\nBarangay: Bagumbayan ? Salapungan\r\nMobile: 09364493600 ? +639364493600\r\nRegion: Region IV-A ? Region III (Central Luzon)','patient_data',10,'02:18:51','2025-11-07'),(10,1,'sadmin','Update','Updated patient record:\r\nBirthday: 26/06/2004 ? 2004-06-26\r\nCity: Iloilo City ? Bakun\r\nBarangay: San Roque ? Bagu\r\nMobile: 09415500808 ? +639415500808\r\nRegion: Region IV-A ? Cordillera Administrative Region (CAR)','patient_data',1,'02:19:06','2025-11-07'),(11,1,'sadmin','Update','Updated patient record:\r\nBirthday: 19/07/1981 ? 1981-07-19\r\nCity: Antipolo ? Danao City\r\nBarangay: Poblacion ? Masaba\r\nMobile: 09380434361 ? +639380434361\r\nRegion: Region IV-A ? Region VII (Central Visayas)','patient_data',2,'02:19:30','2025-11-07'),(12,1,'sadmin','Update','Updated patient record:\r\nBirthday: 01/02/1990 ? 1990-02-01\r\nProvince: Davao del Sur ? Misamis Occidental\r\nCity: Cebu City ? Bonifacio\r\nBarangay: Bagumbayan ? Tusik\r\nMobile: 09571365431 ? +639571365431\r\nRegion: Region IV-A ? Region X (Northern Mindanao)','patient_data',3,'02:19:49','2025-11-07'),(13,1,'sadmin','Update','Updated patient record:\r\nBirthday: 25/04/2003 ? 2003-04-25\r\nProvince: Batangas ? Quezon\r\nCity: Taguig ? Padre Burgos\r\nBarangay: Sta. Cruz ? Walay\r\nMobile: 09461084481 ? +639461084481\r\nGender: Male ? Female\r\nRegion: Region IV-A ? Region IV-A (CALABARZON)','patient_data',4,'02:20:08','2025-11-07'),(14,1,'sadmin','Update','Updated patient record:\r\nBirthday: 03/07/1996 ? 1996-07-03\r\nCity: Antipolo ? City Of Antipolo\r\nBarangay: Sta. Cruz ? Calawis\r\nMobile: 09223111465 ? +639223111465\r\nRegion: Region IV-A ? Region IV-A (CALABARZON)','patient_data',5,'02:20:23','2025-11-07'),(15,1,'sadmin','Update','Updated patient record:\r\nBirthday: 26/10/1985 ? 1985-10-26\r\nProvince: Davao del Sur ? Isabela\r\nCity: Taguig ? Quezon\r\nBarangay: Sta. Cruz ? Barucboc Norte\r\nMobile: 09860521254 ? +639860521254\r\nRegion: Region IV-A ? Region II (Cagayan Valley)','patient_data',6,'02:20:37','2025-11-07'),(16,1,'sadmin','Update','Updated patient record:\r\nBirthday: 21/01/2005 ? 2005-01-21\r\nProvince: Davao del Sur ? City Of Manila\r\nCity: Antipolo ? San Nicolas\r\nBarangay: Balibago ? Barangay 269\r\nMobile: 09903073182 ? +639903073182\r\nRegion: Region IV-A ? National Capital Region (NCR)','patient_data',7,'02:20:53','2025-11-07'),(17,1,'sadmin','Update','Updated patient record:\r\nBirthday: 16/08/2001 ? 2001-08-16\r\nProvince: Rizal ? La Union\r\nCity: Iloilo City ? Balaoan\r\nBarangay: Bagumbayan ? Pa-o\r\nMobile: 09205215544 ? +639205215544\r\nRegion: Region IV-A ? Region I (Ilocos Region)','patient_data',8,'02:21:06','2025-11-07'),(18,1,'sadmin','Update','Updated patient record:\r\nBirthday: 22/09/1983 ? 1983-09-22\r\nProvince: Davao del Sur ? Sulu\r\nCity: Antipolo ? Maimbung\r\nBarangay: San Isidro ? Tubig-Samin\r\nMobile: 09967032773 ? +639967032773\r\nRegion: Region IV-A ? Autonomous Region in Muslim Mindanao (ARMM)','patient_data',9,'02:21:24','2025-11-07'),(19,1,'sadmin','Update','Updated doctor named Jose Ramos Torres','tbl_doctor',10,'02:22:03','2025-11-07'),(20,1,'sadmin','Update','Updated doctor named Liza Lopez Navarro','tbl_doctor',9,'02:22:10','2025-11-07'),(21,1,'sadmin','Update','Updated doctor named Antonio Navarro Garcia','tbl_doctor',8,'02:22:17','2025-11-07'),(22,1,'sadmin','Update','Updated doctor named Pedro Bautista Navarro','tbl_doctor',7,'02:22:25','2025-11-07'),(23,1,'sadmin','Update','Updated doctor named Jose Torres Cruz','tbl_doctor',6,'02:22:35','2025-11-07'),(24,1,'sadmin','Update','Updated doctor named Miguel Reyes Torres','tbl_doctor',5,'02:22:48','2025-11-07'),(25,1,'sadmin','Update','Updated doctor named Carmen Torres Santos','tbl_doctor',4,'02:22:56','2025-11-07'),(26,1,'sadmin','Update','Updated doctor named Miguel Garcia Cruz','tbl_doctor',3,'02:23:03','2025-11-07'),(27,1,'sadmin','Update','Updated doctor named Jose Navarro Bautista','tbl_doctor',2,'02:23:10','2025-11-07'),(28,1,'sadmin','Update','Updated doctor named Ana Dela Santos','tbl_doctor',1,'02:23:18','2025-11-07'),(29,1,'sadmin','Login','User logged in',NULL,NULL,'02:24:02','2025-11-07'),(30,1,'sadmin','Place Order','Placed a new order with Order ID: 1 and Total Amount: 95000',NULL,NULL,'02:24:19','2025-11-07'),(31,1,'sadmin','Login','User logged in',NULL,NULL,'02:25:33','2025-11-07'),(32,1,'sadmin','Place Order','Placed a new order with Order ID: 2 and Total Amount: 9000',NULL,NULL,'02:25:56','2025-11-07'),(33,1,'sadmin','Place Order','Placed a new order with Order ID: 3 and Total Amount: 74000',NULL,NULL,'02:26:34','2025-11-07'),(34,1,'sadmin','Place Order','Placed a new order with Order ID: 4 and Total Amount: 96500',NULL,NULL,'02:27:59','2025-11-07'),(35,1,'sadmin','Cancel Order','Order ID 4: Order partially completed - remaining items cancelled',NULL,NULL,'02:28:40','2025-11-07'),(36,1,'sadmin','Place Order','Placed a new order with Order ID: 5 and Total Amount: 96850',NULL,NULL,'02:28:59','2025-11-07'),(37,1,'sadmin','Login','User logged in',NULL,NULL,'02:30:55','2025-11-07'),(38,1,'sadmin','Login','User logged in',NULL,NULL,'02:33:39','2025-11-07'),(39,1,'sadmin','Login','User logged in',NULL,NULL,'02:34:09','2025-11-07'),(40,1,'sadmin','Login','User logged in',NULL,NULL,'02:35:15','2025-11-07'),(41,1,'sadmin','Login','User logged in',NULL,NULL,'02:43:04','2025-11-07'),(42,1,'sadmin','Login','User logged in',NULL,NULL,'02:44:13','2025-11-07'),(43,1,'sadmin','Login','User logged in',NULL,NULL,'02:49:03','2025-11-07'),(44,1,'sadmin','Login','User logged in',NULL,NULL,'02:51:57','2025-11-07'),(45,1,'sadmin','Login','User logged in',NULL,NULL,'02:54:21','2025-11-07'),(46,1,'sadmin','Login','User logged in',NULL,NULL,'02:55:38','2025-11-07'),(47,1,'sadmin','Login','User logged in',NULL,NULL,'02:56:29','2025-11-07'),(48,1,'sadmin','Update Product','Updated product: Acetate Eyeglass Frame Classic Black',NULL,NULL,'02:57:27','2025-11-07'),(49,1,'sadmin','Login','User logged in',NULL,NULL,'02:59:08','2025-11-07'),(50,1,'sadmin','Login','User logged in',NULL,NULL,'03:05:18','2025-11-07'),(51,1,'sadmin','Login','User logged in',NULL,NULL,'03:05:53','2025-11-07'),(52,1,'sadmin','Login','User logged in',NULL,NULL,'03:08:19','2025-11-07'),(53,1,'sadmin','Login','User logged in',NULL,NULL,'03:10:22','2025-11-07'),(54,1,'sadmin','Update Product','Updated product: Anti-Static Lens Cleaner 100ml',NULL,NULL,'03:11:01','2025-11-07'),(55,1,'sadmin','Insert','Added checkup record for Juan Garcia Reyes','tbl_checkup',1,'03:12:28','2025-11-07'),(56,1,'sadmin','Insert','Added new transaction for Juan Garcia Reyes with total of 1350.00 and paid ?500','tbl_transactionstbl_transaction_items',1,'03:12:28','2025-11-07'),(57,1,'sadmin','Login','User logged in',NULL,NULL,'03:14:52','2025-11-07'),(58,1,'sadmin','Login','User logged in',NULL,NULL,'03:18:09','2025-11-07'),(59,1,'sadmin','Settle','Settled payment of ?850.00 for patient: Juan Garcia Reyes. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',1,'03:18:31','2025-11-07'),(60,1,'sadmin','Insert','Added checkup record for ','tbl_checkup',2,'03:20:06','2025-11-07'),(61,1,'sadmin','Insert','Added new transaction for Juan Navarro Santos with total of 1225.00 and paid ?300','tbl_transactionstbl_transaction_items',2,'03:20:06','2025-11-07'),(62,1,'sadmin','Login','User logged in',NULL,NULL,'03:21:18','2025-11-07'),(63,1,'sadmin','Login','User logged in',NULL,NULL,'03:23:46','2025-11-07'),(64,1,'sadmin','Login','User logged in',NULL,NULL,'03:27:48','2025-11-07'),(65,1,'sadmin','Login','User logged in',NULL,NULL,'03:32:57','2025-11-07'),(66,1,'sadmin','Update Product','Updated product: Contact Lens Solution 60ml',NULL,NULL,'03:34:01','2025-11-07'),(67,1,'sadmin','Update Product','Updated product: Polarized Sunglasses Aviator Style',NULL,NULL,'03:34:19','2025-11-07'),(68,1,'sadmin','Update Product','Updated product: Contact Lens Solution 60ml',NULL,NULL,'03:34:35','2025-11-07'),(69,1,'sadmin','Update Product','Updated product: Anti-Static Lens Cleaner 100ml',NULL,NULL,'03:34:46','2025-11-07'),(70,1,'sadmin','Login','User logged in',NULL,NULL,'03:37:25','2025-11-07'),(71,1,'sadmin','Login','User logged in',NULL,NULL,'03:39:59','2025-11-07'),(72,1,'sadmin','Update Product','Updated product: Rimless Titanium Frame',NULL,NULL,'03:40:52','2025-11-07'),(73,1,'sadmin','Update Product','Updated product: Hard Case with Cleaning Cloth',NULL,NULL,'03:41:06','2025-11-07'),(74,1,'sadmin','Update Product','Updated product: Progressive Multifocal Lens',NULL,NULL,'03:41:29','2025-11-07'),(75,1,'sadmin','Update Product','Updated product: Lens Repair Kit',NULL,NULL,'03:41:44','2025-11-07'),(76,1,'sadmin','Settle','Settled payment of ?925.00 for patient: Juan Navarro Santos. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',2,'03:42:18','2025-11-07'),(77,1,'sadmin','Insert','Added checkup record for Maria Bautista Ramos','tbl_checkup',3,'03:43:04','2025-11-07'),(78,1,'sadmin','Insert','Added new transaction for Maria Bautista Ramos with total of 400 and paid ?400','tbl_transactionstbl_transaction_items',3,'03:43:04','2025-11-07'),(79,1,'sadmin','Insert','Added new transaction for Rosa Lopez Navarro with total of 2695.00 and paid ?400','tbl_transactionstbl_transaction_items',4,'03:44:26','2025-11-07'),(80,1,'sadmin','Login','User logged in',NULL,NULL,'03:45:59','2025-11-07'),(81,1,'sadmin','Login','User logged in',NULL,NULL,'03:55:34','2025-11-07'),(82,1,'sadmin','Insert','Added checkup record for Pedro Lopez Cruz','tbl_checkup',4,'03:56:39','2025-11-07'),(83,1,'sadmin','Insert','Added new transaction for Pedro Lopez Cruz with total of 1000 and paid ?300','tbl_transactionstbl_transaction_items',5,'03:56:40','2025-11-07'),(84,1,'sadmin','Login','User logged in',NULL,NULL,'03:58:54','2025-11-07'),(85,1,'sadmin','Login','User logged in',NULL,NULL,'04:08:03','2025-11-07'),(86,1,'sadmin','Login','User logged in',NULL,NULL,'04:12:22','2025-11-07'),(87,1,'sadmin','Stock In','Received 5 of Acetate Eyeglass Frame Classic Black',NULL,NULL,'04:13:03','2025-11-07'),(88,1,'sadmin','Stock In','Received 5 of Anti-Static Lens Cleaner 100Ml',NULL,NULL,'04:13:25','2025-11-07'),(89,1,'sadmin','Stock Out','Issued 5 of Lens Repair Kit for left over',NULL,NULL,'04:14:18','2025-11-07'),(90,1,'sadmin','Login','User logged in',NULL,NULL,'04:20:18','2025-11-07'),(91,1,'sadmin','Login','User logged in',NULL,NULL,'04:22:18','2025-11-07'),(92,1,'sadmin','Login','User logged in',NULL,NULL,'04:23:33','2025-11-07'),(93,1,'sadmin','Login','User logged in',NULL,NULL,'04:24:37','2025-11-07'),(94,1,'sadmin','Login','User logged in',NULL,NULL,'04:28:41','2025-11-07'),(95,1,'sadmin','Login','User logged in',NULL,NULL,'04:29:01','2025-11-07'),(96,1,'sadmin','Login','User logged in',NULL,NULL,'04:34:06','2025-11-07'),(97,1,'sadmin','Login','User logged in',NULL,NULL,'04:38:01','2025-11-07'),(98,1,'sadmin','Login','User logged in',NULL,NULL,'04:41:06','2025-11-07'),(99,1,'sadmin','Add User','Added user: recep',NULL,NULL,'04:43:22','2025-11-07'),(100,1,'sadmin','Add User','Added user: opto',NULL,NULL,'04:44:21','2025-11-07'),(101,1,'sadmin','Add User','Added user: admin',NULL,NULL,'04:44:51','2025-11-07'),(102,1,'sadmin','Login','User logged in',NULL,NULL,'04:51:36','2025-11-07'),(103,1,'sadmin','Login','User logged in',NULL,NULL,'04:54:07','2025-11-07'),(104,1,'sadmin','Login','User logged in',NULL,NULL,'04:57:43','2025-11-07'),(105,1,'sadmin','Login','User logged in',NULL,NULL,'05:02:07','2025-11-07'),(106,1,'sadmin','Update Product','Updated product: Lens Repair Kit',NULL,NULL,'05:03:17','2025-11-07'),(107,1,'sadmin','Update Product','Updated product: Lens Repair Kit',NULL,NULL,'05:03:31','2025-11-07'),(108,1,'sadmin','Login','User logged in',NULL,NULL,'05:12:53','2025-11-07'),(109,1,'sadmin','Login','User logged in',NULL,NULL,'07:30:04','2025-11-07'),(110,1,'sadmin','Login','User logged in',NULL,NULL,'07:33:12','2025-11-07'),(111,1,'sadmin','Insert','Added new transaction for Carmen Santos Reyes with total of 300.00 and paid ?300.00','tbl_transactionstbl_transaction_items',10,'07:33:34','2025-11-07'),(112,1,'sadmin','Insert','Added new transaction for Liza Bautista Reyes with total of 1250.00 and paid ?1250.00','tbl_transactionstbl_transaction_items',9,'07:33:57','2025-11-07'),(113,1,'sadmin','Insert','Added new transaction for Antonio Navarro Lopez with total of 200.00 and paid ?200.00','tbl_transactionstbl_transaction_items',8,'07:34:20','2025-11-07'),(114,1,'sadmin','Insert','Added new transaction for Juan Lopez Santos with total of 2280.00 and paid ?200.00','tbl_transactionstbl_transaction_items',7,'07:34:55','2025-11-07'),(115,1,'sadmin','Insert','Added new transaction for Carmen Torres Garcia with total of 6750.00 and paid ?6750.00','tbl_transactionstbl_transaction_items',6,'07:35:30','2025-11-07'),(116,1,'sadmin','Insert','Added new transaction for Carmen Santos Reyes with total of 690.00 and paid ?690.00','tbl_transactionstbl_transaction_items',10,'07:36:28','2025-11-07'),(117,1,'sadmin','Insert','Added new transaction for Liza Bautista Reyes with total of 5250.00 and paid ?5250.00','tbl_transactionstbl_transaction_items',9,'07:36:50','2025-11-07'),(118,1,'sadmin','Insert','Added checkup record for Antonio Navarro Lopez','tbl_checkup',5,'07:37:28','2025-11-07'),(119,1,'sadmin','Insert','Added new transaction for Antonio Navarro Lopez with total of 300.00 and paid ?300.00','tbl_transactionstbl_transaction_items',8,'07:37:28','2025-11-07'),(120,1,'sadmin','Insert','Added new transaction for Carmen Torres Garcia with total of 9350.00 and paid ?9350.00','tbl_transactionstbl_transaction_items',6,'07:38:09','2025-11-07'),(121,1,'sadmin','Stock In','Received 10 of Anti-Static Lens Cleaner 100Ml',NULL,NULL,'08:06:57','2025-11-07'),(122,1,'sadmin','Stock Out','Issued 10 of Anti-Static Lens Cleaner 100Ml for Defective',NULL,NULL,'08:07:28','2025-11-07'),(123,1,'sadmin','Login','User logged in',NULL,NULL,'09:01:45','2025-11-07'),(124,1,'sadmin','Login','User logged in',NULL,NULL,'09:04:12','2025-11-07'),(125,1,'sadmin','Login','User logged in',NULL,NULL,'09:04:51','2025-11-07'),(126,4,'admin','Login','User logged in',NULL,NULL,'09:05:17','2025-11-07'),(127,3,'opto','Login','User logged in',NULL,NULL,'09:05:44','2025-11-07'),(128,2,'recep','Login','User logged in',NULL,NULL,'09:06:09','2025-11-07'),(129,1,'sadmin','Login','User logged in',NULL,NULL,'09:06:57','2025-11-07'),(130,1,'sadmin','Login','User logged in',NULL,NULL,'09:08:31','2025-11-07'),(131,1,'sadmin','Login','User logged in',NULL,NULL,'09:09:03','2025-11-07'),(132,1,'sadmin','Login','User logged in',NULL,NULL,'09:09:56','2025-11-07'),(133,1,'sadmin','Login','User logged in',NULL,NULL,'09:10:26','2025-11-07'),(134,1,'sadmin','Login','User logged in',NULL,NULL,'09:11:27','2025-11-07'),(135,2,'recep','Login','User logged in',NULL,NULL,'10:34:25','2025-11-07'),(136,2,'recep','Update Profile','changed password',NULL,NULL,'10:35:11','2025-11-07'),(137,2,'recep','Login','User logged in',NULL,NULL,'10:35:33','2025-11-07'),(138,2,'recep','Login','User logged in',NULL,NULL,'10:56:03','2025-11-07'),(139,2,'recep','Insert','Added checkup record for Liza Bautista Reyes','tbl_checkup',6,'11:38:41','2025-11-07'),(140,2,'recep','Insert','Added new transaction for Liza Bautista Reyes with total of 5000.00 and paid ?100','tbl_transactionstbl_transaction_items',9,'11:38:41','2025-11-07'),(141,2,'recep','Settle','Settled payment of ?4,900.00 for patient: Liza Bautista Reyes. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',15,'11:45:59','2025-11-07'),(142,1,'sadmin','Login','User logged in',NULL,NULL,'11:47:32','2025-11-07'),(143,1,'sadmin','Login','User logged in',NULL,NULL,'22:06:45','2025-11-07'),(144,1,'sadmin','Login','User logged in',NULL,NULL,'22:25:08','2025-11-07'),(145,1,'sadmin','Login','User logged in',NULL,NULL,'22:35:09','2025-11-07'),(146,1,'sadmin','Login','User logged in',NULL,NULL,'23:02:28','2025-11-07'),(147,1,'sadmin','Login','User logged in',NULL,NULL,'23:03:26','2025-11-07'),(148,1,'sadmin','Login','User logged in',NULL,NULL,'19:45:47','2025-11-08'),(149,1,'sadmin','Login','User logged in',NULL,NULL,'20:40:42','2025-11-08'),(150,1,'sadmin','Insert','Added new patient: qwe qwe','patient_data',11,'20:41:25','2025-11-08'),(151,1,'sadmin','Insert','Added checkup record for Qwe Qwe Qwe','tbl_checkup',7,'20:42:14','2025-11-08'),(152,1,'sadmin','Insert','Added new transaction for Qwe Qwe Qwe with total of 1000 and paid ?300','tbl_transactionstbl_transaction_items',11,'20:42:14','2025-11-08'),(153,1,'sadmin','Settle','Settled payment of ?700.00 for patient: Qwe Qwe Qwe. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',16,'20:42:56','2025-11-08'),(154,1,'sadmin','Place Order','Placed a new order with Order ID: 6 and Total Amount: 4750',NULL,NULL,'20:43:17','2025-11-08'),(155,1,'sadmin','Login','User logged in',NULL,NULL,'21:06:51','2025-11-08'),(156,1,'sadmin','Login','User logged in',NULL,NULL,'21:08:50','2025-11-08'),(157,1,'sadmin','Login','User logged in',NULL,NULL,'21:14:33','2025-11-08'),(158,1,'sadmin','Login','User logged in',NULL,NULL,'21:15:07','2025-11-08'),(159,1,'sadmin','Login','User logged in',NULL,NULL,'21:15:37','2025-11-08'),(160,1,'sadmin','Login','User logged in',NULL,NULL,'21:16:09','2025-11-08'),(161,1,'sadmin','Login','User logged in',NULL,NULL,'21:16:29','2025-11-08'),(162,1,'sadmin','Login','User logged in',NULL,NULL,'21:17:14','2025-11-08'),(163,1,'sadmin','Login','User logged in',NULL,NULL,'21:17:34','2025-11-08'),(164,1,'sadmin','Login','User logged in',NULL,NULL,'21:18:25','2025-11-08'),(165,1,'sadmin','Login','User logged in',NULL,NULL,'21:19:02','2025-11-08'),(166,1,'sadmin','Login','User logged in',NULL,NULL,'21:20:28','2025-11-08'),(167,1,'sadmin','Login','User logged in',NULL,NULL,'21:23:19','2025-11-08'),(168,1,'sadmin','Login','User logged in',NULL,NULL,'21:23:48','2025-11-08'),(169,1,'sadmin','Login','User logged in',NULL,NULL,'21:29:20','2025-11-08'),(170,1,'sadmin','Login','User logged in',NULL,NULL,'21:31:59','2025-11-08'),(171,1,'sadmin','Login','User logged in',NULL,NULL,'21:37:56','2025-11-08'),(172,1,'sadmin','Login','User logged in',NULL,NULL,'21:47:19','2025-11-08'),(173,1,'sadmin','Login','User logged in',NULL,NULL,'21:49:35','2025-11-08'),(174,1,'sadmin','Login','User logged in',NULL,NULL,'21:51:42','2025-11-08'),(175,1,'sadmin','Login','User logged in',NULL,NULL,'22:56:54','2025-11-08'),(176,1,'sadmin','Login','User logged in',NULL,NULL,'23:00:05','2025-11-08'),(177,4,'admin','Login','User logged in',NULL,NULL,'23:00:31','2025-11-08'),(178,1,'sadmin','Login','User logged in',NULL,NULL,'23:41:05','2025-11-08'),(179,1,'sadmin','Add User','Added user: recep1',NULL,NULL,'23:42:38','2025-11-08'),(180,1,'sadmin','Login','User logged in',NULL,NULL,'00:10:18','2025-11-09'),(181,1,'sadmin','Update User','Update User: recep1',NULL,NULL,'00:10:48','2025-11-09'),(182,1,'sadmin','Login','User logged in',NULL,NULL,'00:18:00','2025-11-09'),(183,1,'sadmin','Login','User logged in',NULL,NULL,'00:38:23','2025-11-09'),(184,1,'sadmin','Update User','Update User: recep1',NULL,NULL,'00:42:17','2025-11-09'),(185,1,'sadmin','Login','User logged in',NULL,NULL,'00:54:01','2025-11-09'),(186,1,'sadmin','Login','User logged in',NULL,NULL,'01:02:35','2025-11-09'),(187,1,'sadmin','Add User','Added user: opto1',NULL,NULL,'01:04:00','2025-11-09'),(188,1,'sadmin','Login','User logged in',NULL,NULL,'01:09:16','2025-11-09'),(189,1,'sadmin','Add User','Added user: lg',NULL,NULL,'01:10:27','2025-11-09'),(190,7,'lg','Login','User logged in',NULL,NULL,'01:11:22','2025-11-09'),(191,1,'sadmin','Login','User logged in',NULL,NULL,'01:37:49','2025-11-09'),(192,1,'sadmin','Login','User logged in',NULL,NULL,'02:22:40','2025-11-09'),(193,1,'sadmin','Login','User logged in',NULL,NULL,'02:25:32','2025-11-09'),(194,1,'sadmin','Login','User logged in',NULL,NULL,'16:51:38','2025-11-10'),(195,1,'sadmin','Login','User logged in',NULL,NULL,'16:52:51','2025-11-10'),(196,1,'sadmin','Login','User logged in',NULL,NULL,'16:53:37','2025-11-10'),(197,1,'sadmin','Login','User logged in',NULL,NULL,'16:57:12','2025-11-10'),(198,1,'sadmin','Login','User logged in',NULL,NULL,'16:57:34','2025-11-10'),(199,1,'sadmin','Login','User logged in',NULL,NULL,'16:57:55','2025-11-10'),(200,1,'sadmin','Login','User logged in',NULL,NULL,'17:16:46','2025-11-10'),(201,1,'sadmin','Login','User logged in',NULL,NULL,'17:19:27','2025-11-10'),(202,1,'sadmin','Update Profile','changed suffix from \'\' to \'N/A\'; changed date of birth from \'\' to \'2000-02-01\'',NULL,NULL,'17:20:08','2025-11-10'),(203,1,'sadmin','Login','User logged in',NULL,NULL,'17:31:39','2025-11-10'),(204,1,'sadmin','Login','User logged in',NULL,NULL,'17:54:23','2025-11-10'),(205,1,'sadmin','Login','User logged in',NULL,NULL,'17:58:09','2025-11-10'),(206,1,'sadmin','Login','User logged in',NULL,NULL,'17:59:09','2025-11-10'),(207,1,'sadmin','Login','User logged in',NULL,NULL,'18:01:31','2025-11-10'),(208,1,'sadmin','Login','User logged in',NULL,NULL,'18:02:04','2025-11-10'),(209,1,'sadmin','Login','User logged in',NULL,NULL,'18:23:21','2025-11-10'),(210,1,'sadmin','Login','User logged in',NULL,NULL,'18:28:31','2025-11-10'),(211,1,'sadmin','Login','User logged in',NULL,NULL,'18:29:28','2025-11-10'),(212,1,'sadmin','Login','User logged in',NULL,NULL,'18:33:42','2025-11-10'),(213,1,'sadmin','Add User','Added user: opto2',NULL,NULL,'18:34:44','2025-11-10'),(214,1,'sadmin','Login','User logged in',NULL,NULL,'18:35:09','2025-11-10'),(215,8,'opto2','Login','User logged in',NULL,NULL,'18:36:06','2025-11-10'),(216,1,'sadmin','Login','User logged in',NULL,NULL,'18:49:21','2025-11-10'),(217,1,'sadmin','Login','User logged in',NULL,NULL,'18:55:22','2025-11-10'),(218,1,'sadmin','Login','User logged in',NULL,NULL,'18:59:11','2025-11-10'),(219,1,'sadmin','Login','User logged in',NULL,NULL,'19:18:03','2025-11-10'),(220,1,'sadmin','Login','User logged in',NULL,NULL,'19:34:58','2025-11-10'),(221,1,'sadmin','Login','User logged in',NULL,NULL,'19:38:32','2025-11-10'),(222,1,'sadmin','Login','User logged in',NULL,NULL,'19:40:33','2025-11-10'),(223,1,'sadmin','Login','User logged in',NULL,NULL,'19:42:24','2025-11-10'),(224,1,'sadmin','Login','User logged in',NULL,NULL,'19:44:20','2025-11-10'),(225,1,'sadmin','Login','User logged in',NULL,NULL,'22:26:43','2025-11-10'),(226,1,'sadmin','Login','User logged in',NULL,NULL,'22:47:41','2025-11-10'),(227,1,'sadmin','Login','User logged in',NULL,NULL,'23:49:11','2025-11-10'),(228,1,'sadmin','Login','User logged in',NULL,NULL,'00:51:14','2025-11-11'),(229,1,'sadmin','Login','User logged in',NULL,NULL,'03:15:41','2025-11-11'),(230,1,'sadmin','Login','User logged in',NULL,NULL,'03:17:05','2025-11-11'),(231,1,'sadmin','Login','User logged in',NULL,NULL,'03:17:47','2025-11-11'),(232,1,'sadmin','Login','User logged in',NULL,NULL,'03:19:41','2025-11-11'),(233,1,'sadmin','Login','User logged in',NULL,NULL,'03:20:42','2025-11-11'),(234,1,'sadmin','Login','User logged in',NULL,NULL,'03:21:32','2025-11-11'),(235,1,'sadmin','Login','User logged in',NULL,NULL,'03:22:03','2025-11-11'),(236,1,'sadmin','Login','User logged in',NULL,NULL,'03:22:38','2025-11-11'),(237,1,'sadmin','Login','User logged in',NULL,NULL,'03:24:22','2025-11-11'),(238,1,'sadmin','Login','User logged in',NULL,NULL,'03:25:04','2025-11-11'),(239,1,'sadmin','Login','User logged in',NULL,NULL,'03:25:32','2025-11-11'),(240,1,'sadmin','Login','User logged in',NULL,NULL,'03:26:10','2025-11-11'),(241,1,'sadmin','Login','User logged in',NULL,NULL,'03:26:57','2025-11-11'),(242,1,'sadmin','Login','User logged in',NULL,NULL,'03:27:42','2025-11-11'),(243,1,'sadmin','Login','User logged in',NULL,NULL,'03:28:48','2025-11-11'),(244,1,'sadmin','Login','User logged in',NULL,NULL,'03:33:38','2025-11-11'),(245,1,'sadmin','Login','User logged in',NULL,NULL,'19:25:14','2025-11-11'),(246,1,'sadmin','Login','User logged in',NULL,NULL,'19:28:45','2025-11-11'),(247,1,'sadmin','Login','User logged in',NULL,NULL,'20:20:34','2025-11-11'),(248,1,'sadmin','Login','User logged in',NULL,NULL,'20:32:09','2025-11-11'),(249,1,'sadmin','Login','User logged in',NULL,NULL,'20:42:36','2025-11-11'),(250,1,'sadmin','Login','User logged in',NULL,NULL,'20:46:59','2025-11-11'),(251,1,'sadmin','Login','User logged in',NULL,NULL,'20:51:56','2025-11-11'),(252,1,'sadmin','Login','User logged in',NULL,NULL,'20:57:03','2025-11-11'),(253,1,'sadmin','Login','User logged in',NULL,NULL,'21:45:08','2025-11-11'),(254,1,'sadmin','Login','User logged in',NULL,NULL,'21:48:37','2025-11-11'),(255,1,'sadmin','Login','User logged in',NULL,NULL,'21:50:31','2025-11-11'),(256,1,'sadmin','Login','User logged in',NULL,NULL,'21:54:10','2025-11-11'),(257,1,'sadmin','Login','User logged in',NULL,NULL,'21:57:59','2025-11-11'),(258,1,'sadmin','Login','User logged in',NULL,NULL,'23:03:18','2025-11-11'),(259,1,'sadmin','Login','User logged in',NULL,NULL,'23:05:38','2025-11-11'),(260,1,'sadmin','Login','User logged in',NULL,NULL,'23:07:59','2025-11-11'),(261,1,'sadmin','Login','User logged in',NULL,NULL,'23:09:25','2025-11-11'),(262,1,'sadmin','Login','User logged in',NULL,NULL,'23:10:16','2025-11-11'),(263,1,'sadmin','Login','User logged in',NULL,NULL,'23:10:51','2025-11-11'),(264,1,'sadmin','Login','User logged in',NULL,NULL,'23:50:42','2025-11-11'),(265,1,'sadmin','Login','User logged in',NULL,NULL,'23:52:39','2025-11-11'),(266,1,'sadmin','Login','User logged in',NULL,NULL,'23:53:14','2025-11-11'),(267,1,'sadmin','Login','User logged in',NULL,NULL,'23:53:51','2025-11-11'),(268,1,'sadmin','Login','User logged in',NULL,NULL,'23:54:47','2025-11-11'),(269,1,'sadmin','Login','User logged in',NULL,NULL,'23:55:14','2025-11-11'),(270,1,'sadmin','Login','User logged in',NULL,NULL,'23:55:41','2025-11-11'),(271,1,'sadmin','Login','User logged in',NULL,NULL,'23:57:01','2025-11-11'),(272,1,'sadmin','Login','User logged in',NULL,NULL,'23:59:23','2025-11-11'),(273,1,'sadmin','Login','User logged in',NULL,NULL,'00:21:14','2025-11-12'),(274,1,'sadmin','Login','User logged in',NULL,NULL,'00:26:35','2025-11-12'),(275,1,'sadmin','Login','User logged in',NULL,NULL,'00:27:00','2025-11-12'),(276,1,'sadmin','Login','User logged in',NULL,NULL,'00:27:26','2025-11-12'),(277,1,'sadmin','Login','User logged in',NULL,NULL,'00:29:07','2025-11-12'),(278,1,'sadmin','Login','User logged in',NULL,NULL,'00:29:54','2025-11-12'),(279,1,'sadmin','Login','User logged in',NULL,NULL,'00:33:33','2025-11-12'),(280,1,'sadmin','Login','User logged in',NULL,NULL,'00:34:43','2025-11-12'),(281,1,'sadmin','Login','User logged in',NULL,NULL,'00:38:50','2025-11-12'),(282,1,'sadmin','Login','User logged in',NULL,NULL,'01:15:17','2025-11-12'),(283,1,'sadmin','Login','User logged in',NULL,NULL,'01:22:37','2025-11-12'),(284,1,'sadmin','Login','User logged in',NULL,NULL,'01:28:43','2025-11-12'),(285,1,'sadmin','Login','User logged in',NULL,NULL,'01:41:07','2025-11-12'),(286,1,'sadmin','Login','User logged in',NULL,NULL,'02:40:57','2025-11-12'),(287,1,'sadmin','Login','User logged in',NULL,NULL,'02:46:52','2025-11-12'),(288,1,'sadmin','Login','User logged in',NULL,NULL,'02:47:41','2025-11-12'),(289,1,'sadmin','Login','User logged in',NULL,NULL,'02:54:28','2025-11-12'),(290,1,'sadmin','Login','User logged in',NULL,NULL,'03:00:05','2025-11-12'),(291,1,'sadmin','Login','User logged in',NULL,NULL,'03:05:43','2025-11-12'),(292,1,'sadmin','Login','User logged in',NULL,NULL,'03:10:17','2025-11-12'),(293,1,'sadmin','Update','Updated patient record:\r\nBirthday: 26/06/2004 ? 2004-06-26\r\nStreet:  ? 20-c sapamanay st.\r\nOthers:  ? N/A','patient_data',1,'03:11:29','2025-11-12'),(294,1,'sadmin','Login','User logged in',NULL,NULL,'03:20:00','2025-11-12'),(295,1,'sadmin','Login','User logged in',NULL,NULL,'03:33:42','2025-11-12'),(296,1,'sadmin','Login','User logged in',NULL,NULL,'03:45:19','2025-11-12'),(297,1,'sadmin','Login','User logged in',NULL,NULL,'04:07:15','2025-11-12'),(298,1,'sadmin','Login','User logged in',NULL,NULL,'04:24:14','2025-11-12'),(299,1,'sadmin','Login','User logged in',NULL,NULL,'04:44:17','2025-11-12'),(300,1,'sadmin','Login','User logged in',NULL,NULL,'04:45:19','2025-11-12'),(301,1,'sadmin','Login','User logged in',NULL,NULL,'04:45:48','2025-11-12'),(302,1,'sadmin','Login','User logged in',NULL,NULL,'04:46:37','2025-11-12'),(303,1,'sadmin','Login','User logged in',NULL,NULL,'16:43:08','2025-11-12'),(304,1,'sadmin','Login','User logged in',NULL,NULL,'16:44:14','2025-11-12'),(305,1,'sadmin','Login','User logged in',NULL,NULL,'17:50:35','2025-11-12'),(306,1,'sadmin','Login','User logged in',NULL,NULL,'18:06:22','2025-11-12'),(307,1,'sadmin','Login','User logged in',NULL,NULL,'18:38:54','2025-11-12'),(308,1,'sadmin','Login','User logged in',NULL,NULL,'18:39:59','2025-11-12'),(309,1,'sadmin','Login','User logged in',NULL,NULL,'18:44:57','2025-11-12'),(310,1,'sadmin','Login','User logged in',NULL,NULL,'18:58:14','2025-11-12'),(311,1,'sadmin','Login','User logged in',NULL,NULL,'19:03:49','2025-11-12'),(312,1,'sadmin','Login','User logged in',NULL,NULL,'19:06:30','2025-11-12'),(313,1,'sadmin','Login','User logged in',NULL,NULL,'19:18:12','2025-11-12'),(314,1,'sadmin','Login','User logged in',NULL,NULL,'19:21:29','2025-11-12'),(315,1,'sadmin','Login','User logged in',NULL,NULL,'19:24:46','2025-11-12'),(316,1,'sadmin','Login','User logged in',NULL,NULL,'19:27:52','2025-11-12'),(317,1,'sadmin','Login','User logged in',NULL,NULL,'19:43:56','2025-11-12'),(318,1,'sadmin','Login','User logged in',NULL,NULL,'19:50:03','2025-11-12'),(319,1,'sadmin','Login','User logged in',NULL,NULL,'20:12:42','2025-11-12'),(320,1,'sadmin','Update','Updated patient record:\r\nMiddle Name: Qwe ? N/A\r\nLast Name: Qwe ? try\r\nBirthday: 20/02/1988 ? 1988-02-20\r\nProvince: Pampanga ? Second District\r\nCity: Arayat ? City Of Mandaluyong\r\nBarangay: Matamo (Santa Lucia) ? Plainview\r\nStreet:  ? blk 10 binondo st.\r\nOthers:  ? N/A\r\nHighblood: Yes ? No\r\nRegion: Region III (Central Luzon) ? National Capital Region (NCR)','patient_data',11,'20:14:30','2025-11-12'),(321,1,'sadmin','Login','User logged in',NULL,NULL,'20:28:50','2025-11-12'),(322,1,'sadmin','Login','User logged in',NULL,NULL,'20:38:12','2025-11-12'),(323,1,'sadmin','Login','User logged in',NULL,NULL,'20:52:12','2025-11-12'),(324,1,'sadmin','Update','Updated patient record:\r\nMiddle Name: N/A ? m\r\nBirthday: 20/02/1988 ? 1988-02-20','patient_data',11,'20:53:30','2025-11-12'),(325,1,'sadmin','Update','Updated patient record:\r\nBirthday: 08/10/1987 ? 1987-10-08\r\nProvince: Pampanga ? Second District\r\nCity: Candaba ? City Of Mandaluyong\r\nBarangay: Salapungan ? Plainview\r\nStreet:  ? hahahahha\r\nOthers:  ? N/A\r\nRegion: Region III (Central Luzon) ? National Capital Region (NCR)','patient_data',10,'20:56:18','2025-11-12'),(326,1,'sadmin','Login','User logged in',NULL,NULL,'21:05:56','2025-11-12'),(327,1,'sadmin','Login','User logged in',NULL,NULL,'21:11:19','2025-11-12'),(328,1,'sadmin','Insert','Added new patient: angelo royce morales','patient_data',12,'21:17:38','2025-11-12'),(329,1,'sadmin','Login','User logged in',NULL,NULL,'21:23:50','2025-11-12'),(330,1,'sadmin','Login','User logged in',NULL,NULL,'21:26:36','2025-11-12'),(331,1,'sadmin','Login','User logged in',NULL,NULL,'21:34:35','2025-11-12'),(332,1,'sadmin','Login','User logged in',NULL,NULL,'21:35:50','2025-11-12'),(333,1,'sadmin','Login','User logged in',NULL,NULL,'21:38:09','2025-11-12'),(334,1,'sadmin','Login','User logged in',NULL,NULL,'21:43:01','2025-11-12'),(335,1,'sadmin','Login','User logged in',NULL,NULL,'21:49:30','2025-11-12'),(336,1,'sadmin','Login','User logged in',NULL,NULL,'22:38:26','2025-11-12'),(337,1,'sadmin','Login','User logged in',NULL,NULL,'22:41:10','2025-11-12'),(338,1,'sadmin','Login','User logged in',NULL,NULL,'22:55:22','2025-11-12'),(339,1,'sadmin','Login','User logged in',NULL,NULL,'23:00:18','2025-11-12'),(340,1,'sadmin','Login','User logged in',NULL,NULL,'23:03:07','2025-11-12'),(341,1,'sadmin','Login','User logged in',NULL,NULL,'23:04:20','2025-11-12'),(342,1,'sadmin','Login','User logged in',NULL,NULL,'23:05:16','2025-11-12'),(343,1,'sadmin','Login','User logged in',NULL,NULL,'23:06:41','2025-11-12'),(344,1,'sadmin','Login','User logged in',NULL,NULL,'23:11:21','2025-11-12'),(345,1,'sadmin','Login','User logged in',NULL,NULL,'23:15:55','2025-11-12'),(346,1,'sadmin','Login','User logged in',NULL,NULL,'23:16:24','2025-11-12'),(347,1,'sadmin','Login','User logged in',NULL,NULL,'23:17:26','2025-11-12'),(348,1,'sadmin','Login','User logged in',NULL,NULL,'00:56:33','2025-11-13'),(349,1,'sadmin','Login','User logged in',NULL,NULL,'00:57:14','2025-11-13'),(350,1,'sadmin','Login','User logged in',NULL,NULL,'00:58:54','2025-11-13'),(351,1,'sadmin','Login','User logged in',NULL,NULL,'01:00:04','2025-11-13'),(352,1,'sadmin','Login','User logged in',NULL,NULL,'01:01:26','2025-11-13'),(353,1,'sadmin','Login','User logged in',NULL,NULL,'01:06:47','2025-11-13'),(354,1,'sadmin','Login','User logged in',NULL,NULL,'01:09:38','2025-11-13'),(355,1,'sadmin','Login','User logged in',NULL,NULL,'01:11:37','2025-11-13'),(356,1,'sadmin','Login','User logged in',NULL,NULL,'01:13:15','2025-11-13'),(357,1,'sadmin','Login','User logged in',NULL,NULL,'01:15:31','2025-11-13'),(358,1,'sadmin','Login','User logged in',NULL,NULL,'01:17:55','2025-11-13'),(359,1,'sadmin','Login','User logged in',NULL,NULL,'01:18:49','2025-11-13'),(360,1,'sadmin','Login','User logged in',NULL,NULL,'01:20:30','2025-11-13'),(361,1,'sadmin','Login','User logged in',NULL,NULL,'01:27:23','2025-11-13'),(362,1,'sadmin','Login','User logged in',NULL,NULL,'01:30:13','2025-11-13'),(363,1,'sadmin','Login','User logged in',NULL,NULL,'01:38:57','2025-11-13'),(364,1,'sadmin','Login','User logged in',NULL,NULL,'01:39:27','2025-11-13'),(365,1,'sadmin','Login','User logged in',NULL,NULL,'01:39:56','2025-11-13'),(366,1,'sadmin','Login','User logged in',NULL,NULL,'01:40:26','2025-11-13'),(367,1,'sadmin','Login','User logged in',NULL,NULL,'01:41:12','2025-11-13'),(368,1,'sadmin','Login','User logged in',NULL,NULL,'01:42:40','2025-11-13'),(369,1,'sadmin','Login','User logged in',NULL,NULL,'01:43:35','2025-11-13'),(370,1,'sadmin','Login','User logged in',NULL,NULL,'01:44:13','2025-11-13'),(371,1,'sadmin','Login','User logged in',NULL,NULL,'01:44:49','2025-11-13'),(372,1,'sadmin','Login','User logged in',NULL,NULL,'01:45:18','2025-11-13'),(373,1,'sadmin','Login','User logged in',NULL,NULL,'01:45:47','2025-11-13'),(374,1,'sadmin','Login','User logged in',NULL,NULL,'01:46:34','2025-11-13'),(375,1,'sadmin','Login','User logged in',NULL,NULL,'01:51:15','2025-11-13'),(376,1,'sadmin','Login','User logged in',NULL,NULL,'01:56:37','2025-11-13'),(377,1,'sadmin','Login','User logged in',NULL,NULL,'01:59:28','2025-11-13'),(378,1,'sadmin','Login','User logged in',NULL,NULL,'01:59:53','2025-11-13'),(379,1,'sadmin','Login','User logged in',NULL,NULL,'02:00:21','2025-11-13'),(380,1,'sadmin','Login','User logged in',NULL,NULL,'02:11:59','2025-11-13'),(381,1,'sadmin','Update','Updated patient record:\r\nFirst Name: Qwe ? christian jay\r\nMiddle Name: M ? N/A\r\nLast Name: Try ? almerol\r\nBirthday: 20/02/1988 ? 1988-02-20\r\nGender: Female ? Male','patient_data',11,'02:14:50','2025-11-13'),(382,1,'sadmin','Login','User logged in',NULL,NULL,'02:20:03','2025-11-13'),(383,1,'sadmin','Login','User logged in',NULL,NULL,'02:21:57','2025-11-13'),(384,1,'sadmin','Login','User logged in',NULL,NULL,'02:23:02','2025-11-13'),(385,1,'sadmin','Login','User logged in',NULL,NULL,'02:24:04','2025-11-13'),(386,1,'sadmin','Login','User logged in',NULL,NULL,'02:27:42','2025-11-13'),(387,1,'sadmin','Login','User logged in',NULL,NULL,'02:30:49','2025-11-13'),(388,1,'sadmin','Login','User logged in',NULL,NULL,'02:32:30','2025-11-13'),(389,1,'sadmin','Login','User logged in',NULL,NULL,'02:35:16','2025-11-13'),(390,1,'sadmin','Login','User logged in',NULL,NULL,'02:37:38','2025-11-13'),(391,1,'sadmin','Login','User logged in',NULL,NULL,'02:38:09','2025-11-13'),(392,1,'sadmin','Login','User logged in',NULL,NULL,'02:46:09','2025-11-13'),(393,1,'sadmin','Login','User logged in',NULL,NULL,'02:47:03','2025-11-13'),(394,1,'sadmin','Login','User logged in',NULL,NULL,'02:50:12','2025-11-13'),(395,1,'sadmin','Login','User logged in',NULL,NULL,'02:51:22','2025-11-13'),(396,1,'sadmin','Login','User logged in',NULL,NULL,'02:55:15','2025-11-13'),(397,1,'sadmin','Insert','Created appointment for patientID 6 with doctor Ana Dela Santos','tbl_appointments',6,'02:56:12','2025-11-13'),(398,1,'sadmin','Login','User logged in',NULL,NULL,'03:00:08','2025-11-13'),(399,1,'sadmin','Insert','Created appointment for patientID 12 with doctor Miguel Reyes Torres','tbl_appointments',12,'03:01:02','2025-11-13'),(400,1,'sadmin','Login','User logged in',NULL,NULL,'03:06:21','2025-11-13'),(401,1,'sadmin','Login','User logged in',NULL,NULL,'03:11:47','2025-11-13'),(402,1,'sadmin','Login','User logged in',NULL,NULL,'03:18:24','2025-11-13'),(403,1,'sadmin','Login','User logged in',NULL,NULL,'03:24:10','2025-11-13'),(404,1,'sadmin','Login','User logged in',NULL,NULL,'03:26:07','2025-11-13'),(405,1,'sadmin','Settle','Settled payment of ?300.00 for patient: Angelo Royce Morales. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',17,'03:26:35','2025-11-13'),(406,1,'sadmin','Login','User logged in',NULL,NULL,'03:29:15','2025-11-13'),(407,1,'sadmin','Settle','Settled payment of ?940.00 for patient: Liza Bautista Reyes. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',18,'03:32:34','2025-11-13'),(408,1,'sadmin','Settle','Settled payment of ?1,000.00 for patient: Juan Lopez Santos. Remaining balance: ?0.00','tbl_transactions, tbl_transaction_items',19,'03:33:32','2025-11-13'),(409,1,'sadmin','Login','User logged in',NULL,NULL,'03:36:05','2025-11-13'),(410,1,'sadmin','Login','User logged in',NULL,NULL,'03:40:58','2025-11-13'),(411,1,'sadmin','Login','User logged in',NULL,NULL,'03:43:16','2025-11-13'),(412,1,'sadmin','Login','User logged in',NULL,NULL,'03:46:35','2025-11-13'),(413,1,'sadmin','Login','User logged in',NULL,NULL,'11:48:51','2025-11-13'),(414,1,'sadmin','Login','User logged in',NULL,NULL,'12:32:31','2025-11-13'),(415,1,'sadmin','Login','User logged in',NULL,NULL,'12:38:31','2025-11-13'),(416,1,'sadmin','Login','User logged in',NULL,NULL,'12:43:40','2025-11-13'),(417,1,'sadmin','Login','User logged in',NULL,NULL,'12:44:48','2025-11-13'),(418,1,'sadmin','Login','User logged in',NULL,NULL,'12:45:24','2025-11-13'),(419,1,'sadmin','Login','User logged in',NULL,NULL,'12:46:40','2025-11-13'),(420,1,'sadmin','Login','User logged in',NULL,NULL,'12:48:59','2025-11-13'),(421,1,'sadmin','Login','User logged in',NULL,NULL,'12:52:03','2025-11-13'),(422,1,'sadmin','Login','User logged in',NULL,NULL,'12:56:12','2025-11-13'),(423,1,'sadmin','Login','User logged in',NULL,NULL,'19:43:40','2025-11-14'),(424,1,'sadmin','Login','User logged in',NULL,NULL,'20:49:18','2025-11-14'),(425,1,'sadmin','Login','User logged in',NULL,NULL,'20:51:29','2025-11-14'),(426,1,'sadmin','Login','User logged in',NULL,NULL,'20:52:51','2025-11-14'),(427,1,'sadmin','Login','User logged in',NULL,NULL,'20:54:00','2025-11-14'),(428,1,'sadmin','Login','User logged in',NULL,NULL,'20:54:26','2025-11-14'),(429,1,'sadmin','Login','User logged in',NULL,NULL,'20:58:46','2025-11-14'),(430,1,'sadmin','Login','User logged in',NULL,NULL,'20:59:51','2025-11-14'),(431,1,'sadmin','Login','User logged in',NULL,NULL,'22:53:28','2025-11-14'),(432,1,'sadmin','Login','User logged in',NULL,NULL,'23:21:30','2025-11-14'),(433,1,'sadmin','Login','User logged in',NULL,NULL,'23:43:57','2025-11-14'),(434,1,'sadmin','Login','User logged in',NULL,NULL,'00:37:32','2025-11-15'),(435,1,'sadmin','Login','User logged in',NULL,NULL,'01:02:31','2025-11-15'),(436,1,'sadmin','Login','User logged in',NULL,NULL,'01:03:16','2025-11-15'),(437,1,'sadmin','Login','User logged in',NULL,NULL,'01:04:11','2025-11-15'),(438,1,'sadmin','Login','User logged in',NULL,NULL,'01:05:19','2025-11-15'),(439,1,'sadmin','Login','User logged in',NULL,NULL,'01:06:29','2025-11-15'),(440,1,'sadmin','Login','User logged in',NULL,NULL,'01:06:49','2025-11-15'),(441,1,'sadmin','Login','User logged in',NULL,NULL,'01:07:06','2025-11-15'),(442,1,'sadmin','Login','User logged in',NULL,NULL,'01:07:41','2025-11-15'),(443,1,'sadmin','Login','User logged in',NULL,NULL,'01:08:08','2025-11-15'),(444,1,'sadmin','Login','User logged in',NULL,NULL,'01:10:10','2025-11-15'),(445,1,'sadmin','Login','User logged in',NULL,NULL,'01:10:55','2025-11-15'),(446,1,'sadmin','Login','User logged in',NULL,NULL,'01:11:52','2025-11-15'),(447,1,'sadmin','Login','User logged in',NULL,NULL,'01:18:51','2025-11-15'),(448,1,'sadmin','Login','User logged in',NULL,NULL,'01:19:14','2025-11-15'),(449,1,'sadmin','Login','User logged in',NULL,NULL,'01:19:30','2025-11-15'),(450,1,'sadmin','Login','User logged in',NULL,NULL,'01:19:49','2025-11-15'),(451,1,'sadmin','Login','User logged in',NULL,NULL,'01:47:00','2025-11-15'),(452,1,'sadmin','Login','User logged in',NULL,NULL,'01:48:28','2025-11-15'),(453,1,'sadmin','Login','User logged in',NULL,NULL,'01:55:55','2025-11-15'),(454,1,'sadmin','Login','User logged in',NULL,NULL,'01:59:52','2025-11-15'),(455,1,'sadmin','Login','User logged in',NULL,NULL,'02:06:29','2025-11-15'),(456,1,'sadmin','Login','User logged in',NULL,NULL,'02:08:57','2025-11-15'),(457,1,'sadmin','Login','User logged in',NULL,NULL,'02:14:05','2025-11-15'),(458,1,'sadmin','Login','User logged in',NULL,NULL,'02:36:57','2025-11-15'),(459,1,'sadmin','Login','User logged in',NULL,NULL,'02:38:44','2025-11-15'),(460,1,'sadmin','Login','User logged in',NULL,NULL,'02:49:18','2025-11-15'),(461,1,'sadmin','Login','User logged in',NULL,NULL,'02:50:01','2025-11-15'),(462,1,'sadmin','Login','User logged in',NULL,NULL,'02:51:34','2025-11-15'),(463,1,'sadmin','Login','User logged in',NULL,NULL,'02:54:24','2025-11-15'),(464,1,'sadmin','Login','User logged in',NULL,NULL,'02:56:13','2025-11-15'),(465,1,'sadmin','Login','User logged in',NULL,NULL,'02:56:59','2025-11-15'),(466,1,'sadmin','Login','User logged in',NULL,NULL,'02:58:22','2025-11-15'),(467,1,'sadmin','Login','User logged in',NULL,NULL,'03:00:27','2025-11-15'),(468,1,'sadmin','Login','User logged in',NULL,NULL,'03:02:20','2025-11-15'),(469,1,'sadmin','Login','User logged in',NULL,NULL,'03:27:02','2025-11-15'),(470,1,'sadmin','Login','User logged in',NULL,NULL,'03:27:52','2025-11-15'),(471,1,'sadmin','Login','User logged in',NULL,NULL,'03:28:14','2025-11-15'),(472,1,'sadmin','Login','User logged in',NULL,NULL,'03:29:01','2025-11-15'),(473,1,'sadmin','Login','User logged in',NULL,NULL,'03:31:18','2025-11-15'),(474,1,'sadmin','Login','User logged in',NULL,NULL,'03:39:53','2025-11-15'),(475,1,'sadmin','Login','User logged in',NULL,NULL,'03:50:15','2025-11-15'),(476,1,'sadmin','Login','User logged in',NULL,NULL,'03:56:45','2025-11-15'),(477,1,'sadmin','Login','User logged in',NULL,NULL,'04:02:53','2025-11-15'),(478,1,'sadmin','Login','User logged in',NULL,NULL,'04:14:20','2025-11-15'),(479,1,'sadmin','Login','User logged in',NULL,NULL,'04:16:07','2025-11-15'),(480,1,'sadmin','Login','User logged in',NULL,NULL,'04:16:51','2025-11-15'),(481,1,'sadmin','Login','User logged in',NULL,NULL,'04:17:15','2025-11-15'),(482,1,'sadmin','Login','User logged in',NULL,NULL,'04:18:00','2025-11-15'),(483,1,'sadmin','Login','User logged in',NULL,NULL,'04:18:29','2025-11-15'),(484,1,'sadmin','Login','User logged in',NULL,NULL,'04:18:45','2025-11-15'),(485,1,'sadmin','Login','User logged in',NULL,NULL,'04:21:21','2025-11-15'),(486,1,'sadmin','Login','User logged in',NULL,NULL,'04:27:47','2025-11-15'),(487,1,'sadmin','Login','User logged in',NULL,NULL,'04:30:29','2025-11-15'),(488,1,'sadmin','Insert','Created appointment for patientID 11 with doctor Jose Navarro Bautista','tbl_appointments',11,'04:30:59','2025-11-15'),(489,1,'sadmin','Login','User logged in',NULL,NULL,'04:34:18','2025-11-15'),(490,1,'sadmin','Insert','Created appointment for patientID 11 with doctor Ana Dela Santos','tbl_appointments',11,'04:34:30','2025-11-15'),(491,1,'sadmin','Login','User logged in',NULL,NULL,'04:37:38','2025-11-15'),(492,1,'sadmin','Login','User logged in',NULL,NULL,'04:44:53','2025-11-15'),(493,1,'sadmin','Login','User logged in',NULL,NULL,'04:47:52','2025-11-15'),(494,1,'sadmin','Login','User logged in',NULL,NULL,'04:49:27','2025-11-15'),(495,1,'sadmin','Login','User logged in',NULL,NULL,'04:50:31','2025-11-15'),(496,1,'sadmin','Login','User logged in',NULL,NULL,'04:52:53','2025-11-15'),(497,1,'sadmin','Login','User logged in',NULL,NULL,'04:54:33','2025-11-15'),(498,1,'sadmin','Login','User logged in',NULL,NULL,'17:46:56','2025-11-16'),(499,1,'sadmin','Login','User logged in',NULL,NULL,'17:51:56','2025-11-16'),(500,1,'sadmin','Login','User logged in',NULL,NULL,'17:55:41','2025-11-16'),(501,1,'sadmin','Login','User logged in',NULL,NULL,'17:58:09','2025-11-16'),(502,1,'sadmin','Login','User logged in',NULL,NULL,'18:15:14','2025-11-16'),(503,1,'sadmin','Login','User logged in',NULL,NULL,'18:20:26','2025-11-16'),(504,1,'sadmin','Login','User logged in',NULL,NULL,'18:25:18','2025-11-16'),(505,1,'sadmin','Login','User logged in',NULL,NULL,'18:30:35','2025-11-16'),(506,1,'sadmin','Login','User logged in',NULL,NULL,'18:33:33','2025-11-16'),(507,1,'sadmin','Login','User logged in',NULL,NULL,'18:36:45','2025-11-16'),(508,1,'sadmin','Login','User logged in',NULL,NULL,'18:44:34','2025-11-16'),(509,1,'sadmin','Login','User logged in',NULL,NULL,'18:49:30','2025-11-16'),(510,1,'sadmin','Login','User logged in',NULL,NULL,'18:50:16','2025-11-16'),(511,1,'sadmin','Login','User logged in',NULL,NULL,'18:52:09','2025-11-16'),(512,1,'sadmin','Login','User logged in',NULL,NULL,'18:53:15','2025-11-16'),(513,1,'sadmin','Login','User logged in',NULL,NULL,'18:56:02','2025-11-16'),(514,1,'sadmin','Login','User logged in',NULL,NULL,'18:59:24','2025-11-16'),(515,1,'sadmin','Login','User logged in',NULL,NULL,'19:02:03','2025-11-16'),(516,1,'sadmin','Login','User logged in',NULL,NULL,'19:05:12','2025-11-16'),(517,1,'sadmin','Login','User logged in',NULL,NULL,'19:06:54','2025-11-16'),(518,1,'sadmin','Login','User logged in',NULL,NULL,'19:22:25','2025-11-16'),(519,1,'sadmin','Login','User logged in',NULL,NULL,'19:22:54','2025-11-16'),(520,1,'sadmin','Login','User logged in',NULL,NULL,'19:26:11','2025-11-16'),(521,1,'sadmin','Login','User logged in',NULL,NULL,'19:57:24','2025-11-16'),(522,1,'sadmin','Login','User logged in',NULL,NULL,'20:06:26','2025-11-16'),(523,1,'sadmin','Login','User logged in',NULL,NULL,'20:48:39','2025-11-16'),(524,1,'sadmin','Login','User logged in',NULL,NULL,'20:53:13','2025-11-16'),(525,1,'sadmin','Login','User logged in',NULL,NULL,'20:56:17','2025-11-16'),(526,1,'sadmin','Login','User logged in',NULL,NULL,'21:16:38','2025-11-16'),(527,1,'sadmin','Login','User logged in',NULL,NULL,'21:19:27','2025-11-16'),(528,1,'sadmin','Login','User logged in',NULL,NULL,'21:22:49','2025-11-16'),(529,1,'sadmin','Login','User logged in',NULL,NULL,'21:24:05','2025-11-16'),(530,1,'sadmin','Login','User logged in',NULL,NULL,'21:25:43','2025-11-16'),(531,1,'sadmin','Login','User logged in',NULL,NULL,'21:32:48','2025-11-16'),(532,1,'sadmin','Login','User logged in',NULL,NULL,'21:36:05','2025-11-16'),(533,1,'sadmin','Login','User logged in',NULL,NULL,'00:28:41','2025-11-17'),(534,1,'sadmin','Login','User logged in',NULL,NULL,'04:03:32','2025-11-17'),(535,1,'sadmin','Login','User logged in',NULL,NULL,'15:52:16','2025-11-17'),(536,1,'sadmin','Login','User logged in',NULL,NULL,'16:12:38','2025-11-17'),(537,1,'sadmin','Login','User logged in',NULL,NULL,'16:28:01','2025-11-17'),(538,1,'sadmin','Login','User logged in',NULL,NULL,'16:34:16','2025-11-17'),(539,1,'sadmin','Login','User logged in',NULL,NULL,'16:47:29','2025-11-17'),(540,1,'sadmin','Login','User logged in',NULL,NULL,'16:49:56','2025-11-17'),(541,1,'sadmin','Login','User logged in',NULL,NULL,'16:50:26','2025-11-17'),(542,1,'sadmin','Login','User logged in',NULL,NULL,'17:23:59','2025-11-17');

UNLOCK TABLES;

/*Table structure for table `tbl_checkup` */

DROP TABLE IF EXISTS `tbl_checkup`;

CREATE TABLE `tbl_checkup` (
  `checkupID` int(11) NOT NULL AUTO_INCREMENT,
  `patientID` int(11) NOT NULL,
  `checkupDate` date NOT NULL,
  `remarks` text NOT NULL,
  `doctorID` int(11) NOT NULL,
  `sphereOD` varchar(10) DEFAULT NULL,
  `sphereOS` varchar(10) DEFAULT NULL,
  `cylinderOD` varchar(10) DEFAULT NULL,
  `cylinderOS` varchar(10) DEFAULT NULL,
  `axisOD` varchar(10) DEFAULT NULL,
  `axisOS` varchar(10) DEFAULT NULL,
  `addOD` varchar(10) DEFAULT NULL,
  `addOS` varchar(10) DEFAULT NULL,
  `pdOD` varchar(10) DEFAULT NULL,
  `pdOS` varchar(10) DEFAULT NULL,
  `pdOU` varchar(10) DEFAULT NULL,
  `appointmentDate` date DEFAULT NULL,
  `appointedDoctor` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`checkupID`),
  KEY `patientID` (`patientID`),
  KEY `fk_doctor` (`doctorID`),
  CONSTRAINT `fk_doctor` FOREIGN KEY (`doctorID`) REFERENCES `tbl_doctor` (`doctorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tbl_checkup_ibfk_1` FOREIGN KEY (`patientID`) REFERENCES `patient_data` (`patientID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_checkup` */

LOCK TABLES `tbl_checkup` WRITE;

insert  into `tbl_checkup`(`checkupID`,`patientID`,`checkupDate`,`remarks`,`doctorID`,`sphereOD`,`sphereOS`,`cylinderOD`,`cylinderOS`,`axisOD`,`axisOS`,`addOD`,`addOS`,`pdOD`,`pdOS`,`pdOU`,`appointmentDate`,`appointedDoctor`) values (1,1,'2023-03-07','N/A',3,'0','0','0','0','0','0','0','0','0','0','0',NULL,NULL),(2,2,'2025-11-07','N/A',1,'0','0','0','0','0','0','0','0','0','0','0',NULL,NULL),(3,3,'2025-11-07','N/A',8,'0','0','0','0','0','0','0','0','0','0','0',NULL,NULL),(4,5,'2025-11-07','N/A',4,'0','0','0','0','0','0','0','0','0','0','0',NULL,NULL),(5,8,'2025-11-07','N/A',10,'-5.20','-5.20','-5.20','-5.20','-5.20','-5.20','-5.20','-5.20','0','0','-5.20',NULL,NULL),(6,9,'2025-11-07','N/A',2,'-10000','-10000','-10000','-10000','-10000','-10000','-10000','-10000','-10000','-10000','-10000',NULL,NULL),(7,11,'2025-11-08','N/A',1,'0','0','0','0','0','0','0','0','0','0','0',NULL,NULL),(8,6,'2025-11-13','for recommendation',7,'2','0','0','0','6','1','8','9',NULL,NULL,NULL,NULL,NULL),(9,12,'2025-11-13','N/A',5,'0','0','0','0','0','0','0','0',NULL,NULL,NULL,NULL,NULL),(10,4,'2025-11-13','N/A',2,'50','20','1.24','0','0','0','0','0',NULL,NULL,NULL,NULL,NULL),(11,12,'2025-11-13','N/A',6,'0','0','0','0','0','0','0','0',NULL,NULL,NULL,NULL,NULL),(12,12,'2025-11-14','N/A',2,'0','0','0','0','0','0','0','0',NULL,NULL,NULL,NULL,NULL),(13,11,'2025-11-15','N/A',8,'0','0','0','0','0','0','0','0',NULL,NULL,NULL,NULL,NULL);

UNLOCK TABLES;

/*Table structure for table `tbl_doctor` */

DROP TABLE IF EXISTS `tbl_doctor`;

CREATE TABLE `tbl_doctor` (
  `doctorID` int(11) NOT NULL AUTO_INCREMENT,
  `fName` varchar(100) NOT NULL,
  `mName` varchar(100) DEFAULT NULL,
  `lName` varchar(100) NOT NULL,
  `dob` date NOT NULL,
  `contactNumber` varchar(15) NOT NULL,
  `email` varchar(255) NOT NULL,
  `dateAdded` date DEFAULT NULL,
  PRIMARY KEY (`doctorID`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_doctor` */

LOCK TABLES `tbl_doctor` WRITE;

insert  into `tbl_doctor`(`doctorID`,`fName`,`mName`,`lName`,`dob`,`contactNumber`,`email`,`dateAdded`) values (1,'Ana','Dela','Santos','1985-03-15','+639127463475','doc.santos1@clinicph.com',NULL),(2,'Jose','Navarro','Bautista','1982-07-22','+639437512388','doc.bautista2@clinicph.com',NULL),(3,'Miguel','Garcia','Cruz','1990-11-08','+639127313717','doc.cruz3@clinicph.com',NULL),(4,'Carmen','Torres','Santos','1988-05-30','+639237123723','doc.santos4@clinicph.com',NULL),(5,'Miguel','Reyes','Torres','1983-09-12','+639798711997','doc.torres5@clinicph.com',NULL),(6,'Jose','Torres','Cruz','1987-02-18','+639712371232','doc.cruz6@clinicph.com',NULL),(7,'Pedro','Bautista','Navarro','1991-06-25','+639127465743','doc.navarro7@clinicph.com',NULL),(8,'Antonio','Navarro','Garcia','1984-12-03','+639374653435','doc.garcia8@clinicph.com',NULL),(9,'Liza','Lopez','Navarro','1989-04-17','+639768563234','doc.navarro9@clinicph.com',NULL),(10,'Jose','Ramos','Torres','1986-10-28','+639234724234','doc.torres10@clinicph.com',NULL);

UNLOCK TABLES;

/*Table structure for table `tbl_order_deliveries` */

DROP TABLE IF EXISTS `tbl_order_deliveries`;

CREATE TABLE `tbl_order_deliveries` (
  `deliveryID` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) NOT NULL,
  `itemID` int(11) NOT NULL,
  `productID` int(11) DEFAULT NULL,
  `quantityReceived` int(11) NOT NULL,
  `quantityDefective` int(11) NOT NULL DEFAULT 0,
  `remarks` varchar(255) DEFAULT NULL,
  `deliveryDate` date NOT NULL,
  `receivedBy` varchar(255) DEFAULT NULL,
  `deliveryStatus` varchar(20) DEFAULT 'Delivered',
  `productName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`deliveryID`),
  KEY `orderID` (`orderID`),
  KEY `itemID` (`itemID`),
  KEY `productID` (`productID`),
  CONSTRAINT `tbl_order_deliveries_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `tbl_productorders` (`orderID`),
  CONSTRAINT `tbl_order_deliveries_ibfk_2` FOREIGN KEY (`itemID`) REFERENCES `tbl_productorder_items` (`itemID`),
  CONSTRAINT `tbl_order_deliveries_ibfk_3` FOREIGN KEY (`productID`) REFERENCES `tbl_products` (`productID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_order_deliveries` */

LOCK TABLES `tbl_order_deliveries` WRITE;

insert  into `tbl_order_deliveries`(`deliveryID`,`orderID`,`itemID`,`productID`,`quantityReceived`,`quantityDefective`,`remarks`,`deliveryDate`,`receivedBy`,`deliveryStatus`,`productName`) values (1,1,1,NULL,100,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Acetate Eyeglass Frame Classic Black'),(2,2,2,NULL,50,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Anti-Static Lens Cleaner 100ml'),(3,3,3,NULL,50,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Contact Lens Solution 60ml'),(4,3,4,NULL,25,25,'N/A','2025-11-07','Brian Bestudio','Delivered','Polarized Sunglasses Aviator Style'),(5,3,4,NULL,25,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Polarized Sunglasses Aviator Style'),(6,4,6,NULL,25,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Rimless Titanium Frame'),(7,4,5,NULL,40,10,'N/A','2025-11-07','Brian Bestudio','Delivered','Hard Case with Cleaning Cloth'),(8,4,5,NULL,0,0,'Cancelled - 10 items not delivered','2025-11-07','Brian Bestudio','Cancelled','Hard Case with Cleaning Cloth'),(9,4,6,NULL,0,0,'Cancelled - 25 items not delivered','2025-11-07','Brian Bestudio','Cancelled','Rimless Titanium Frame'),(10,5,8,NULL,40,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Progressive Multifocal Lens'),(11,5,7,NULL,30,0,'N/A','2025-11-07','Brian Bestudio','Delivered','Lens Repair Kit'),(12,6,9,1,5,0,'N/A','2025-11-08','Brian Bestudio','Delivered','Acetate Eyeglass Frame Classic Black');

UNLOCK TABLES;

/*Table structure for table `tbl_order_transactions` */

DROP TABLE IF EXISTS `tbl_order_transactions`;

CREATE TABLE `tbl_order_transactions` (
  `transID` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) NOT NULL,
  `status` varchar(30) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `actionTime` datetime NOT NULL,
  PRIMARY KEY (`transID`),
  KEY `orderID` (`orderID`),
  CONSTRAINT `tbl_order_transactions_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `tbl_productorders` (`orderID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_order_transactions` */

LOCK TABLES `tbl_order_transactions` WRITE;

insert  into `tbl_order_transactions`(`transID`,`orderID`,`status`,`remarks`,`actionTime`) values (1,1,'Pending','Delivered successfully','2023-03-09 14:10:00'),(2,2,'Cancelled','Delivered successfully','2024-01-05 12:12:00'),(3,3,'Cancelled','Delivered successfully','2023-03-30 12:01:00'),(4,4,'Pending','Waiting for supplier','2023-07-05 08:38:00'),(5,5,'Delivered','Delivered successfully','2023-11-24 12:44:00'),(6,6,'Cancelled','Waiting for supplier','2024-08-10 13:19:00'),(7,7,'Cancelled','Delivered successfully','2023-07-25 15:05:00'),(8,8,'Processing','Delivered successfully','2023-06-21 13:43:00'),(9,9,'Cancelled','Order confirmed','2025-12-06 13:04:00'),(10,10,'Cancelled','Order confirmed','2024-03-10 08:00:00'),(11,1,'Placed Order','Order placed by Brian Bestudio','2025-11-07 02:24:19'),(12,1,'Received','Updated via Check Products','2025-11-07 02:24:56'),(13,2,'Placed Order','Order placed by Brian Bestudio','2025-11-07 02:25:56'),(14,2,'Received','Updated via Check Products','2025-11-07 02:26:13'),(15,3,'Placed Order','Order placed by Brian Bestudio','2025-11-07 02:26:34'),(16,3,'Partial','Updated via Check Products','2025-11-07 02:26:59'),(17,3,'Received','Updated via Check Products','2025-11-07 02:27:13'),(18,4,'Placed Order','Order placed by Brian Bestudio','2025-11-07 02:28:00'),(19,4,'Partial','Updated via Check Products','2025-11-07 02:28:33'),(20,4,'Completed','Order partially completed - remaining items cancelled','2025-11-07 02:28:40'),(21,5,'Placed Order','Order placed by Brian Bestudio','2025-11-07 02:28:59'),(22,5,'Received','Updated via Check Products','2025-11-07 02:29:23'),(23,6,'Placed Order','Order placed by Brian Bestudio','2025-11-08 20:43:17'),(24,6,'Received','Updated via Check Products','2025-11-08 20:44:22');

UNLOCK TABLES;

/*Table structure for table `tbl_payment_history` */

DROP TABLE IF EXISTS `tbl_payment_history`;

CREATE TABLE `tbl_payment_history` (
  `paymentID` int(11) NOT NULL AUTO_INCREMENT,
  `transactionID` int(11) NOT NULL,
  `paymentAmount` decimal(10,2) NOT NULL,
  `paymentDate` date NOT NULL,
  `paymentTime` time NOT NULL,
  `processedBy` varchar(100) DEFAULT NULL,
  `remarks` text DEFAULT NULL,
  PRIMARY KEY (`paymentID`),
  KEY `idx_transaction` (`transactionID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_payment_history` */

LOCK TABLES `tbl_payment_history` WRITE;

insert  into `tbl_payment_history`(`paymentID`,`transactionID`,`paymentAmount`,`paymentDate`,`paymentTime`,`processedBy`,`remarks`) values (1,1,'1531.18','2025-01-31','12:05:09','Staff','Full payment'),(2,2,'4260.28','2024-08-23','13:36:03','Admin','Initial deposit'),(3,3,'1425.38','2025-10-30','09:03:36','Cashier','Initial deposit'),(4,4,'2888.25','2024-07-27','09:04:10','Admin','Full payment'),(5,5,'1215.55','2023-06-05','09:09:18','Admin','Initial deposit'),(6,6,'2816.07','2023-08-22','08:21:11','Cashier','Initial deposit'),(7,7,'4044.12','2024-02-23','18:37:06','Admin','Partial payment'),(8,8,'4820.55','2024-06-29','09:58:08','Cashier','Initial deposit'),(9,9,'4706.79','2023-08-30','18:38:15','Admin','Full payment'),(10,10,'2124.09','2024-05-07','08:15:52','Staff','Initial deposit'),(11,19,'1000.00','2025-11-13','03:33:32','sadmin','Payment settlement');

UNLOCK TABLES;

/*Table structure for table `tbl_productorder_items` */

DROP TABLE IF EXISTS `tbl_productorder_items`;

CREATE TABLE `tbl_productorder_items` (
  `itemID` int(11) NOT NULL AUTO_INCREMENT,
  `orderID` int(11) DEFAULT NULL,
  `productID` int(11) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `quantityReceived` int(11) DEFAULT 0,
  `quantityDefective` int(11) DEFAULT 0,
  `remarks` varchar(255) DEFAULT NULL,
  `productName` varchar(255) DEFAULT NULL,
  `sProductID` int(11) DEFAULT NULL,
  PRIMARY KEY (`itemID`),
  KEY `orderID` (`orderID`),
  KEY `productID` (`productID`),
  KEY `tbl_productorder_items_ibfk_3` (`sProductID`),
  CONSTRAINT `tbl_productorder_items_ibfk_1` FOREIGN KEY (`orderID`) REFERENCES `tbl_productorders` (`orderID`),
  CONSTRAINT `tbl_productorder_items_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `tbl_products` (`productID`),
  CONSTRAINT `tbl_productorder_items_ibfk_3` FOREIGN KEY (`sProductID`) REFERENCES `tbl_productorder_items` (`itemID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_productorder_items` */

LOCK TABLES `tbl_productorder_items` WRITE;

insert  into `tbl_productorder_items`(`itemID`,`orderID`,`productID`,`quantity`,`quantityReceived`,`quantityDefective`,`remarks`,`productName`,`sProductID`) values (1,1,NULL,100,0,0,NULL,'Acetate Eyeglass Frame Classic Black',NULL),(2,2,NULL,50,0,0,NULL,'Anti-Static Lens Cleaner 100ml',NULL),(3,3,NULL,50,0,0,NULL,'Contact Lens Solution 60ml',NULL),(4,3,NULL,50,0,0,NULL,'Polarized Sunglasses Aviator Style',NULL),(5,4,NULL,50,0,0,NULL,'Hard Case with Cleaning Cloth',NULL),(6,4,NULL,50,0,0,NULL,'Rimless Titanium Frame',NULL),(7,5,NULL,30,0,0,NULL,'Lens Repair Kit',NULL),(8,5,NULL,40,0,0,NULL,'Progressive Multifocal Lens',NULL),(9,6,1,5,0,0,NULL,'Acetate Eyeglass Frame Classic Black',NULL);

UNLOCK TABLES;

/*Table structure for table `tbl_productorders` */

DROP TABLE IF EXISTS `tbl_productorders`;

CREATE TABLE `tbl_productorders` (
  `orderID` int(11) NOT NULL AUTO_INCREMENT,
  `supplierID` int(11) DEFAULT NULL,
  `orderDate` datetime DEFAULT current_timestamp(),
  `totalAmount` decimal(10,2) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `orderedBy` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`orderID`),
  KEY `supplierID` (`supplierID`),
  CONSTRAINT `tbl_productorders_ibfk_1` FOREIGN KEY (`supplierID`) REFERENCES `tbl_suppliers` (`supplierID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_productorders` */

LOCK TABLES `tbl_productorders` WRITE;

insert  into `tbl_productorders`(`orderID`,`supplierID`,`orderDate`,`totalAmount`,`status`,`orderedBy`) values (1,1,'2025-11-07 02:24:10','95000.00','Received','Brian Bestudio'),(2,1,'2025-11-07 02:25:43','9000.00','Received','Brian Bestudio'),(3,2,'2025-11-07 02:26:17','74000.00','Received','Brian Bestudio'),(4,3,'2025-11-07 02:27:45','50500.00','Completed','Brian Bestudio'),(5,4,'2025-11-07 02:28:45','96850.00','Received','Brian Bestudio'),(6,1,'2025-11-08 20:43:05','4750.00','Received','Brian Bestudio');

UNLOCK TABLES;

/*Table structure for table `tbl_products` */

DROP TABLE IF EXISTS `tbl_products`;

CREATE TABLE `tbl_products` (
  `productID` int(11) NOT NULL AUTO_INCREMENT,
  `productName` varchar(255) NOT NULL,
  `category` varchar(100) NOT NULL,
  `stockQuantity` int(11) DEFAULT 0,
  `unitPrice` decimal(10,2) NOT NULL,
  `discount` double DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `reorderLevel` int(11) DEFAULT 0,
  `dateAdded` datetime DEFAULT current_timestamp(),
  `supplierID` int(11) DEFAULT NULL,
  `discountAppliedDate` date DEFAULT NULL,
  `expirationDate` date DEFAULT NULL,
  PRIMARY KEY (`productID`),
  KEY `fk_supplier` (`supplierID`),
  CONSTRAINT `fk_supplier` FOREIGN KEY (`supplierID`) REFERENCES `tbl_suppliers` (`supplierID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_products` */

LOCK TABLES `tbl_products` WRITE;

insert  into `tbl_products`(`productID`,`productName`,`category`,`stockQuantity`,`unitPrice`,`discount`,`description`,`reorderLevel`,`dateAdded`,`supplierID`,`discountAppliedDate`,`expirationDate`) values (1,'Acetate Eyeglass Frame Classic Black','Frame',106,'1050.00',0,'Durable Acetate Frame With Spring Hinge.',10,'2025-11-07 00:00:00',1,NULL,NULL),(2,'Anti-Static Lens Cleaner 100Ml','Accesories',48,'200.00',0,'Alcohol-Free Formula For Scratch-Free Cleaning.',10,'2025-11-07 00:00:00',1,NULL,NULL),(3,'Contact Lens Solution 60Ml','Solution',44,'300.00',0,'Multi-Purpose Disinfecting And Storage Solution.',10,'2025-11-07 00:00:00',2,NULL,'2028-11-07'),(4,'Polarized Sunglasses Aviator Style','Frame',42,'1350.00',0,'Uv400 Protection With Metal Frame.',10,'2025-11-07 00:00:00',2,NULL,NULL),(5,'Rimless Titanium Frame','Frame',23,'1800.00',0,'Rimless Titanium Frame',5,'2025-11-07 00:00:00',3,NULL,NULL),(6,'Hard Case With Cleaning Cloth','Accesories',23,'300.00',0,'Protective Eyeglass Case With Microfiber Cloth.',10,'2025-11-07 00:00:00',3,NULL,NULL),(7,'Progressive Multifocal Lens','Lens',34,'2500.00',0,'For Near And Distance Correction.',10,'2025-11-07 00:00:00',4,NULL,NULL),(8,'Lens Repair Kit','Accesories',19,'100.00',0.1,'Includes Mini Screwdriver, Screws, And Nose Pads.',10,'2025-11-07 00:00:00',4,'2025-11-07',NULL);

UNLOCK TABLES;

/*Table structure for table `tbl_stock_in` */

DROP TABLE IF EXISTS `tbl_stock_in`;

CREATE TABLE `tbl_stock_in` (
  `stockInID` int(11) NOT NULL AUTO_INCREMENT,
  `productID` int(11) NOT NULL,
  `productName` varchar(255) NOT NULL,
  `quantityReceived` int(11) NOT NULL,
  `costPerItem` decimal(10,2) NOT NULL,
  `totalCost` decimal(10,2) NOT NULL,
  `dateReceived` datetime NOT NULL,
  `receivedBy` varchar(255) NOT NULL,
  PRIMARY KEY (`stockInID`),
  KEY `productID` (`productID`),
  CONSTRAINT `productID` FOREIGN KEY (`productID`) REFERENCES `tbl_products` (`productID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_stock_in` */

LOCK TABLES `tbl_stock_in` WRITE;

insert  into `tbl_stock_in`(`stockInID`,`productID`,`productName`,`quantityReceived`,`costPerItem`,`totalCost`,`dateReceived`,`receivedBy`) values (1,1,'',5,'1050.00','5250.00','2025-11-07 00:00:00','Brian Bestudio'),(2,2,'',5,'200.00','1000.00','2025-11-07 00:00:00',''),(3,2,'',10,'200.00','2000.00','2025-11-07 00:00:00','Brian Bestudio');

UNLOCK TABLES;

/*Table structure for table `tbl_stock_out` */

DROP TABLE IF EXISTS `tbl_stock_out`;

CREATE TABLE `tbl_stock_out` (
  `stockOutID` int(11) NOT NULL AUTO_INCREMENT,
  `productID` int(11) NOT NULL,
  `productName` varchar(255) NOT NULL,
  `quantityIssued` int(11) NOT NULL,
  `Reason` varchar(255) NOT NULL,
  `costPerItem` decimal(10,2) NOT NULL,
  `totalCost` decimal(10,2) NOT NULL,
  `IssuedBy` varchar(255) NOT NULL,
  `DateIssued` datetime NOT NULL,
  PRIMARY KEY (`stockOutID`),
  KEY `productID` (`productID`),
  CONSTRAINT `tbl_stock_out_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `tbl_products` (`productID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_stock_out` */

LOCK TABLES `tbl_stock_out` WRITE;

insert  into `tbl_stock_out`(`stockOutID`,`productID`,`productName`,`quantityIssued`,`Reason`,`costPerItem`,`totalCost`,`IssuedBy`,`DateIssued`) values (1,8,'',5,'left over','100.00','500.00','Brian Bestudio','2025-11-07 00:00:00'),(2,2,'',10,'Defective','200.00','2000.00','Brian Bestudio','2025-11-07 00:00:00');

UNLOCK TABLES;

/*Table structure for table `tbl_supplier_products` */

DROP TABLE IF EXISTS `tbl_supplier_products`;

CREATE TABLE `tbl_supplier_products` (
  `sProductID` int(11) NOT NULL AUTO_INCREMENT,
  `supplierID` int(11) DEFAULT NULL,
  `product_name` varchar(150) NOT NULL,
  `category` varchar(100) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `product_price` decimal(10,2) NOT NULL DEFAULT 0.00,
  `status` enum('Active','Inactive') DEFAULT 'Active',
  PRIMARY KEY (`sProductID`),
  KEY `supplierID` (`supplierID`),
  CONSTRAINT `tbl_supplier_products_ibfk_1` FOREIGN KEY (`supplierID`) REFERENCES `tbl_suppliers` (`supplierID`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_supplier_products` */

LOCK TABLES `tbl_supplier_products` WRITE;

insert  into `tbl_supplier_products`(`sProductID`,`supplierID`,`product_name`,`category`,`description`,`product_price`,`status`) values (1,1,'Acetate Eyeglass Frame Classic Black','Frame','Durable acetate frame with spring hinge.','950.00','Active'),(2,1,'Anti-Static Lens Cleaner 100ml','Accesories','Alcohol-free formula for scratch-free cleaning.','180.00','Active'),(3,2,'Polarized Sunglasses Aviator Style','Frame','UV400 protection with metal frame.','1250.00','Active'),(4,2,'Contact Lens Solution 60ml','Solution','Multi-purpose disinfecting and storage solution.','230.00','Active'),(5,3,'Rimless Titanium Frame','Frame','Rimless Titanium Frame','1780.00','Active'),(6,3,'Hard Case with Cleaning Cloth','Accesories','Protective eyeglass case with microfiber cloth.','150.00','Active'),(7,4,'Progressive Multifocal Lens','Lens','For near and distance correction.','2350.00','Active'),(8,4,'Lens Repair Kit','Accesories','Includes mini screwdriver, screws, and nose pads.','95.00','Active');

UNLOCK TABLES;

/*Table structure for table `tbl_suppliers` */

DROP TABLE IF EXISTS `tbl_suppliers`;

CREATE TABLE `tbl_suppliers` (
  `supplierID` int(11) NOT NULL AUTO_INCREMENT,
  `supplierName` varchar(255) DEFAULT NULL,
  `contactPerson` varchar(255) DEFAULT NULL,
  `contactNumber` varchar(100) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `dateAdded` datetime DEFAULT current_timestamp(),
  PRIMARY KEY (`supplierID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_suppliers` */

LOCK TABLES `tbl_suppliers` WRITE;

insert  into `tbl_suppliers`(`supplierID`,`supplierName`,`contactPerson`,`contactNumber`,`email`,`address`,`dateAdded`) values (1,'Visioncare Trading','Maria Teresa Santos','+630917456231','contact@visioncaretrading.com','102 Rizal Street, Barangay San Roque, Quezon City','2023-01-14 00:00:00'),(2,'Optilens Enterprises','Juan Miguel Lopez','+639472347238','juan.lopez@optilensent.com','55 Industrial Avenue, Barangay Poblacion, Makati City','2023-02-07 00:00:00'),(3,'Brightview Optical Supplies','Ana Victoria Garcia','+639273446237','av.garcia@brightviewoptical.ph','33 Market Road, Barangay Mabini, Davao City','2024-04-08 00:00:00'),(4,'Clearvision Trading Corp.','Liza Marie Reyes','+639347572374','liza.reyes@clearvisioncorp.com','45 Lopez Street, Barangay San Isidro, Cebu City','2025-06-07 00:00:00');

UNLOCK TABLES;

/*Table structure for table `tbl_transaction_items` */

DROP TABLE IF EXISTS `tbl_transaction_items`;

CREATE TABLE `tbl_transaction_items` (
  `itemID` int(11) NOT NULL AUTO_INCREMENT,
  `transactionID` int(11) NOT NULL,
  `productID` int(11) DEFAULT NULL,
  `productName` varchar(255) DEFAULT NULL,
  `category` varchar(100) DEFAULT NULL,
  `quantity` int(11) DEFAULT 1,
  `unitPrice` decimal(10,2) DEFAULT NULL,
  `priceOD` decimal(10,2) DEFAULT 0.00,
  `priceOS` decimal(10,2) DEFAULT 0.00,
  `odGrade` varchar(50) DEFAULT NULL,
  `osGrade` varchar(50) DEFAULT NULL,
  `totalPrice` decimal(10,2) DEFAULT NULL,
  `isCheckUpItem` tinyint(1) DEFAULT 0,
  `createdAt` date DEFAULT NULL,
  PRIMARY KEY (`itemID`),
  KEY `fk_trans` (`transactionID`),
  KEY `fk_product` (`productID`),
  CONSTRAINT `fk_product` FOREIGN KEY (`productID`) REFERENCES `tbl_products` (`productID`),
  CONSTRAINT `fk_trans` FOREIGN KEY (`transactionID`) REFERENCES `tbl_transactions` (`transactionID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_transaction_items` */

LOCK TABLES `tbl_transaction_items` WRITE;

insert  into `tbl_transaction_items`(`itemID`,`transactionID`,`productID`,`productName`,`category`,`quantity`,`unitPrice`,`priceOD`,`priceOS`,`odGrade`,`osGrade`,`totalPrice`,`isCheckUpItem`,`createdAt`) values (1,1,1,'Acetate Eyeglass Frame Classic Black','Frame',1,'1050.00','0.00','0.00','','','1050.00',1,'2025-11-07'),(2,2,2,'Anti-Static Lens Cleaner 100Ml','Accesories',2,'200.00','0.00','0.00','','','400.00',1,'2025-11-07'),(3,2,1,'Acetate Eyeglass Frame Classic Black','Frame',1,'1050.00','0.00','0.00','','','1050.00',1,'2025-11-07'),(4,4,4,'Polarized Sunglasses Aviator Style','Frame',1,'1350.00','200.00','300.00','-3.00','-5.00','1350.00',0,'2025-11-07'),(5,4,7,'Progressive Multifocal Lens','Lens',1,'2500.00','200.00','300.00','-3.00','-5.00','2500.00',0,'2025-11-07'),(6,5,3,'Contact Lens Solution 60Ml','Solution',1,'300.00','0.00','0.00','','','300.00',1,'2025-11-07'),(7,5,6,'Hard Case With Cleaning Cloth','Accesories',1,'300.00','0.00','0.00','','','300.00',1,'2025-11-07'),(8,6,6,'Hard Case With Cleaning Cloth','Accesories',1,'300.00','0.00','0.00','','','300.00',0,'2025-11-07'),(9,7,1,'Acetate Eyeglass Frame Classic Black','Frame',1,'1050.00','0.00','0.00','','','1050.00',0,'2025-11-07'),(10,7,2,'Anti-Static Lens Cleaner 100Ml','Accesories',1,'200.00','0.00','0.00','','','200.00',0,'2025-11-07'),(11,8,2,'Anti-Static Lens Cleaner 100Ml','Accesories',1,'200.00','0.00','0.00','','','200.00',0,'2025-11-07'),(12,9,3,'Contact Lens Solution 60Ml','Solution',1,'300.00','0.00','0.00','','','300.00',0,'2025-11-07'),(13,9,8,'Lens Repair Kit','Accesories',2,'90.00','0.00','0.00','','','180.00',0,'2025-11-07'),(14,9,5,'Rimless Titanium Frame','Frame',1,'1800.00','0.00','0.00','','','1800.00',0,'2025-11-07'),(15,10,6,'Hard Case With Cleaning Cloth','Accesories',9,'300.00','0.00','0.00','','','2700.00',0,'2025-11-07'),(16,10,4,'Polarized Sunglasses Aviator Style','Frame',3,'1350.00','0.00','0.00','','','4050.00',0,'2025-11-07'),(17,11,2,'Anti-Static Lens Cleaner 100Ml','Accesories',3,'200.00','0.00','0.00','','','600.00',0,'2025-11-07'),(18,11,8,'Lens Repair Kit','Accesories',1,'90.00','0.00','0.00','','','90.00',0,'2025-11-07'),(19,12,3,'Contact Lens Solution 60Ml','Solution',4,'300.00','0.00','0.00','','','1200.00',0,'2025-11-07'),(20,12,4,'Polarized Sunglasses Aviator Style','Frame',3,'1350.00','0.00','0.00','','','4050.00',0,'2025-11-07'),(21,14,6,'Hard Case With Cleaning Cloth','Accesories',4,'300.00','0.00','0.00','','','1200.00',0,'2025-11-07'),(22,14,7,'Progressive Multifocal Lens','Lens',2,'2500.00','0.00','0.00','','','5000.00',0,'2025-11-07'),(23,14,5,'Rimless Titanium Frame','Frame',1,'1800.00','0.00','0.00','','','1800.00',0,'2025-11-07'),(24,14,4,'Polarized Sunglasses Aviator Style','Frame',1,'1350.00','0.00','0.00','','','1350.00',0,'2025-11-07'),(25,15,7,'Progressive Multifocal Lens','Lens',2,'2500.00','0.00','0.00','-4.00','-3.00','5000.00',1,'2025-11-07'),(26,16,6,'Hard Case With Cleaning Cloth','Accesories',2,'300.00','0.00','0.00','','','600.00',1,'2025-11-08'),(27,18,1,'Acetate Eyeglass Frame Classic Black','Frame',1,'840.00','0.00','0.00','','','840.00',1,'2025-11-13'),(28,19,7,'Progressive Multifocal Lens','Lens',1,'1250.00','0.00','0.00','','','1250.00',0,'2025-11-13'),(29,20,8,'Lens Repair Kit','Accesories',3,'100.00','0.00','0.00','','','300.00',0,'2025-11-13');

UNLOCK TABLES;

/*Table structure for table `tbl_transactions` */

DROP TABLE IF EXISTS `tbl_transactions`;

CREATE TABLE `tbl_transactions` (
  `transactionID` int(11) NOT NULL AUTO_INCREMENT,
  `patientID` int(11) NOT NULL,
  `patientName` varchar(255) DEFAULT NULL,
  `totalAmount` decimal(10,2) DEFAULT 0.00,
  `amountPaid` decimal(10,2) DEFAULT 0.00,
  `pendingBalance` decimal(10,2) GENERATED ALWAYS AS (`totalAmount` - `amountPaid`) STORED,
  `paymentType` varchar(50) DEFAULT NULL,
  `transactionDate` date DEFAULT NULL,
  `paymentStatus` varchar(50) DEFAULT NULL,
  `isCheckUp` tinyint(1) DEFAULT 0,
  `discount` decimal(5,2) DEFAULT 0.00,
  `lensDiscount` decimal(5,4) DEFAULT 0.0000,
  `settlementDate` date DEFAULT NULL,
  `referenceNum` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`transactionID`),
  KEY `fk_patient` (`patientID`),
  CONSTRAINT `fk_patient` FOREIGN KEY (`patientID`) REFERENCES `patient_data` (`patientID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_transactions` */

LOCK TABLES `tbl_transactions` WRITE;

insert  into `tbl_transactions`(`transactionID`,`patientID`,`patientName`,`totalAmount`,`amountPaid`,`pendingBalance`,`paymentType`,`transactionDate`,`paymentStatus`,`isCheckUp`,`discount`,`lensDiscount`,`settlementDate`,`referenceNum`) values (1,1,'Juan Garcia Reyes','1350.00','1350.00','0.00','Cash','2025-11-07','Paid',1,'0.00','0.0000','2025-11-07',NULL),(2,2,'Juan Navarro Santos','1225.00','1225.00','0.00','Cash','2025-11-07','Paid',1,'0.50','0.0000','2025-11-07',NULL),(3,3,'Maria Bautista Ramos','400.00','400.00','0.00','Cash','2025-11-07','Paid',1,'0.00','0.0000','2025-11-07',NULL),(4,4,'Rosa Lopez Navarro','2695.00','400.00','2295.00','Cash','2025-11-07','Pending',0,'0.30','0.5000',NULL,NULL),(5,5,'Pedro Lopez Cruz','1000.00','300.00','700.00','Cash','2025-11-07','Pending',1,'0.00','0.0000',NULL,NULL),(6,10,'Carmen Santos Reyes','300.00','300.00','0.00','G-cash','2025-11-02','Paid',0,'0.00','0.0000','2025-11-02',NULL),(7,9,'Liza Bautista Reyes','1250.00','1250.00','0.00','G-cash','2025-11-02','Paid',0,'0.00','0.0000','2025-11-02',NULL),(8,8,'Antonio Navarro Lopez','200.00','200.00','0.00','G-cash','2025-11-03','Paid',0,'0.00','0.0000','2025-11-03',NULL),(9,7,'Juan Lopez Santos','2280.00','200.00','2080.00','Cash','2025-11-03','Pending',0,'0.00','0.0000',NULL,NULL),(10,6,'Carmen Torres Garcia','6750.00','6750.00','0.00','Cash','2025-11-04','Paid',0,'0.00','0.0000','2025-11-04',NULL),(11,10,'Carmen Santos Reyes','690.00','690.00','0.00','G-cash','2025-11-07','Paid',0,'0.00','0.0000','2025-11-07',NULL),(12,9,'Liza Bautista Reyes','5250.00','5250.00','0.00','Cash','2025-11-07','Paid',0,'0.00','0.0000','2025-11-07',NULL),(13,8,'Antonio Navarro Lopez','300.00','300.00','0.00','Cash','2025-11-07','Paid',1,'0.00','0.0000','2025-11-07',NULL),(14,6,'Carmen Torres Garcia','9350.00','9350.00','0.00','Cash','2025-11-07','Paid',0,'0.00','0.0000','2025-11-07',NULL),(15,9,'Liza Bautista Reyes','5000.00','5000.00','0.00','G-cash','2025-11-07','Paid',1,'0.00','0.0000','2025-11-07',NULL),(16,11,'Qwe Qwe Qwe','1000.00','1000.00','0.00','Cash','2025-11-08','Paid',1,'0.00','0.0000','2025-11-08',NULL),(17,12,'Angelo Royce Morales','300.00','300.00','0.00','Cash','2025-11-13','Paid',1,'0.00','0.0000','2025-11-13',''),(18,9,'Liza Bautista Reyes','1140.00','1140.00','0.00','Cash','2025-11-13','Paid',1,'0.20','0.0000','2025-11-13',''),(19,7,'Juan Lopez Santos','1250.00','1250.00','0.00','Cash','2025-11-13','Paid',0,'0.00','0.5000','2025-11-13',''),(20,1,'Juan Garcia Reyes','300.00','300.00','0.00','Cash','2025-11-13','Paid',0,'0.00','0.0000','2025-11-13','');

UNLOCK TABLES;

/*Table structure for table `tbl_users` */

DROP TABLE IF EXISTS `tbl_users`;

CREATE TABLE `tbl_users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` varchar(50) NOT NULL,
  `Fname` varchar(50) NOT NULL,
  `Mname` varchar(50) DEFAULT NULL,
  `Lname` varchar(50) NOT NULL,
  `Suffix` varchar(50) DEFAULT NULL,
  `dob` date NOT NULL,
  `MobileNum` varchar(20) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `isArchived` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `tbl_users` */

LOCK TABLES `tbl_users` WRITE;

insert  into `tbl_users`(`UserID`,`Username`,`Password`,`Role`,`Fname`,`Mname`,`Lname`,`Suffix`,`dob`,`MobileNum`,`Email`,`isArchived`) values (1,'sadmin','s1234','Super Admin','Brian','N/A','Bestudio','N/A','2000-02-01','+639777234288','bestudiobrian@gmail.com',0),(2,'recep','Erin1234','Receptionist','Erin','N/A','Daquiuag',NULL,'0000-00-00','+639123456789','erindaquiuag@gmail.com',0),(3,'opto','1234','Doctor','Emmanuel','N/A','Pineda',NULL,'0000-00-00','+639137134237','emmanuelp@gmail.com',0),(4,'admin','1234','Administrator','Laurenz Jhaymes','Urcia','Tolentino',NULL,'0000-00-00','+639435734573','laurenztolentino@gmail.com',0),(5,'recep1','12345','Receptionist','Joshua','N/A','Mosrales','Jr','2024-02-01','+639234782871','joshua@gmail.com',0),(6,'opto1','br@052003','Doctor','Brian','N/A','Morales','N/A','2003-05-12','+639723727342','brianmorales@gmail.com',0),(7,'lg','lg@12211905','Administrator','Lg','N/A','Tolentino','Iii','1905-12-21','+639812363626','lgt@gmail.com',0),(8,'opto2','ju@03152000','Doctor','Juan','N/A','Delacruz','N/A','2000-03-15','+639812364662','juandelacruz@gmail.com',0);

UNLOCK TABLES;

/*Table structure for table `db_viewannualsales` */

DROP TABLE IF EXISTS `db_viewannualsales`;

/*!50001 DROP VIEW IF EXISTS `db_viewannualsales` */;
/*!50001 DROP TABLE IF EXISTS `db_viewannualsales` */;

/*!50001 CREATE TABLE  `db_viewannualsales`(
 `MonthNumber` int(2) ,
 `MonthName` varchar(9) ,
 `TotalSales` decimal(32,2) ,
 `Year` int(4) 
)*/;

/*Table structure for table `db_viewcheckup` */

DROP TABLE IF EXISTS `db_viewcheckup`;

/*!50001 DROP VIEW IF EXISTS `db_viewcheckup` */;
/*!50001 DROP TABLE IF EXISTS `db_viewcheckup` */;

/*!50001 CREATE TABLE  `db_viewcheckup`(
 `CheckupID` int(11) ,
 `PatientName` varchar(62) ,
 `PatientID` int(5) ,
 `CheckupDoctor` varchar(302) ,
 `AppointedDoctor` varchar(302) ,
 `CheckupDate` date ,
 `AppointmentDate` datetime 
)*/;

/*Table structure for table `db_viewcheckupdetails` */

DROP TABLE IF EXISTS `db_viewcheckupdetails`;

/*!50001 DROP VIEW IF EXISTS `db_viewcheckupdetails` */;
/*!50001 DROP TABLE IF EXISTS `db_viewcheckupdetails` */;

/*!50001 CREATE TABLE  `db_viewcheckupdetails`(
 `CheckupID` int(11) ,
 `PatientName` varchar(62) ,
 `PatientID` int(5) ,
 `DoctorName` varchar(302) ,
 `CheckupDate` date ,
 `sphereOD` varchar(10) ,
 `sphereOS` varchar(10) ,
 `cylinderOD` varchar(10) ,
 `cylinderOS` varchar(10) ,
 `axisOD` varchar(10) ,
 `axisOS` varchar(10) ,
 `addOD` varchar(10) ,
 `addOS` varchar(10) ,
 `pdOD` varchar(10) ,
 `pdOS` varchar(10) ,
 `pdOU` varchar(10) ,
 `remarks` text 
)*/;

/*Table structure for table `db_viewcriticalstocks` */

DROP TABLE IF EXISTS `db_viewcriticalstocks`;

/*!50001 DROP VIEW IF EXISTS `db_viewcriticalstocks` */;
/*!50001 DROP TABLE IF EXISTS `db_viewcriticalstocks` */;

/*!50001 CREATE TABLE  `db_viewcriticalstocks`(
 `ProductID` int(11) ,
 `ProductName` varchar(255) ,
 `Category` varchar(100) ,
 `StockQuantity` int(11) ,
 `ReorderLevel` int(11) ,
 `UnitPrice` decimal(10,2) 
)*/;

/*Table structure for table `db_viewdoctors` */

DROP TABLE IF EXISTS `db_viewdoctors`;

/*!50001 DROP VIEW IF EXISTS `db_viewdoctors` */;
/*!50001 DROP TABLE IF EXISTS `db_viewdoctors` */;

/*!50001 CREATE TABLE  `db_viewdoctors`(
 `doctorID` int(11) ,
 `fullname` varchar(302) ,
 `dob` date ,
 `contactNumber` varchar(15) ,
 `email` varchar(255) ,
 `dateAdded` date 
)*/;

/*Table structure for table `db_viewinventory` */

DROP TABLE IF EXISTS `db_viewinventory`;

/*!50001 DROP VIEW IF EXISTS `db_viewinventory` */;
/*!50001 DROP TABLE IF EXISTS `db_viewinventory` */;

/*!50001 CREATE TABLE  `db_viewinventory`(
 `productID` int(11) ,
 `productName` varchar(255) ,
 `category` varchar(100) ,
 `stockQuantity` int(11) ,
 `unitPrice` decimal(10,2) ,
 `description` varchar(255) ,
 `reorderLevel` int(11) ,
 `dateAdded` datetime ,
 `supplierName` varchar(255) 
)*/;

/*Table structure for table `db_vieworderproducts` */

DROP TABLE IF EXISTS `db_vieworderproducts`;

/*!50001 DROP VIEW IF EXISTS `db_vieworderproducts` */;
/*!50001 DROP TABLE IF EXISTS `db_vieworderproducts` */;

/*!50001 CREATE TABLE  `db_vieworderproducts`(
 `orderID` int(11) ,
 `supplierName` varchar(255) ,
 `orderDate` datetime ,
 `totalAmount` decimal(10,2) ,
 `status` varchar(100) ,
 `orderedBy` varchar(255) 
)*/;

/*Table structure for table `db_viewpatient` */

DROP TABLE IF EXISTS `db_viewpatient`;

/*!50001 DROP VIEW IF EXISTS `db_viewpatient` */;
/*!50001 DROP TABLE IF EXISTS `db_viewpatient` */;

/*!50001 CREATE TABLE  `db_viewpatient`(
 `patientID` int(5) ,
 `fullname` varchar(62) ,
 `age` bigint(21) ,
 `gender` varchar(6) ,
 `bday` date ,
 `address` varchar(308) ,
 `mobilenum` varchar(13) ,
 `date` date 
)*/;

/*Table structure for table `db_viewpatientsearch` */

DROP TABLE IF EXISTS `db_viewpatientsearch`;

/*!50001 DROP VIEW IF EXISTS `db_viewpatientsearch` */;
/*!50001 DROP TABLE IF EXISTS `db_viewpatientsearch` */;

/*!50001 CREATE TABLE  `db_viewpatientsearch`(
 `patientID` int(5) ,
 `fullname` varchar(62) ,
 `bday` date 
)*/;

/*Table structure for table `db_viewproductsearch` */

DROP TABLE IF EXISTS `db_viewproductsearch`;

/*!50001 DROP VIEW IF EXISTS `db_viewproductsearch` */;
/*!50001 DROP TABLE IF EXISTS `db_viewproductsearch` */;

/*!50001 CREATE TABLE  `db_viewproductsearch`(
 `productID` int(11) ,
 `productName` varchar(255) ,
 `category` varchar(100) ,
 `unitPrice` decimal(10,2) ,
 `description` varchar(255) 
)*/;

/*Table structure for table `db_viewsalesreport` */

DROP TABLE IF EXISTS `db_viewsalesreport`;

/*!50001 DROP VIEW IF EXISTS `db_viewsalesreport` */;
/*!50001 DROP TABLE IF EXISTS `db_viewsalesreport` */;

/*!50001 CREATE TABLE  `db_viewsalesreport`(
 `productID` int(11) ,
 `productName` varchar(255) ,
 `category` varchar(100) ,
 `unitPrice` decimal(10,2) ,
 `TransactionDate` date ,
 `QuantitySold` decimal(32,0) ,
 `TotalSales` decimal(42,2) 
)*/;

/*Table structure for table `db_viewstock` */

DROP TABLE IF EXISTS `db_viewstock`;

/*!50001 DROP VIEW IF EXISTS `db_viewstock` */;
/*!50001 DROP TABLE IF EXISTS `db_viewstock` */;

/*!50001 CREATE TABLE  `db_viewstock`(
 `stockInID` int(11) ,
 `productName` varchar(255) ,
 `quantityReceived` int(11) ,
 `costPerItem` decimal(10,2) ,
 `totalCost` decimal(10,2) ,
 `dateReceived` datetime ,
 `receivedBy` varchar(255) 
)*/;

/*Table structure for table `db_viewstockout` */

DROP TABLE IF EXISTS `db_viewstockout`;

/*!50001 DROP VIEW IF EXISTS `db_viewstockout` */;
/*!50001 DROP TABLE IF EXISTS `db_viewstockout` */;

/*!50001 CREATE TABLE  `db_viewstockout`(
 `stockOutID` int(11) ,
 `productName` varchar(255) ,
 `quantityIssued` int(11) ,
 `costPerItem` decimal(10,2) ,
 `totalCost` decimal(10,2) ,
 `Reason` varchar(255) ,
 `IssuedBy` varchar(255) ,
 `DateIssued` datetime 
)*/;

/*Table structure for table `db_viewtransactiondata` */

DROP TABLE IF EXISTS `db_viewtransactiondata`;

/*!50001 DROP VIEW IF EXISTS `db_viewtransactiondata` */;
/*!50001 DROP TABLE IF EXISTS `db_viewtransactiondata` */;

/*!50001 CREATE TABLE  `db_viewtransactiondata`(
 `transactionID` int(11) ,
 `patientID` int(11) ,
 `patientName` varchar(62) ,
 `totalPayment` decimal(10,2) ,
 `amountPaid` decimal(10,2) ,
 `typeOfPayment` varchar(50) ,
 `date` date ,
 `pendingBalance` decimal(10,2) ,
 `paymentStatus` varchar(50) 
)*/;

/*Table structure for table `db_viewuser` */

DROP TABLE IF EXISTS `db_viewuser`;

/*!50001 DROP VIEW IF EXISTS `db_viewuser` */;
/*!50001 DROP TABLE IF EXISTS `db_viewuser` */;

/*!50001 CREATE TABLE  `db_viewuser`(
 `UserID` int(11) ,
 `Username` varchar(50) ,
 `fullname` varchar(152) ,
 `Role` varchar(50) ,
 `MobileNum` varchar(20) ,
 `Email` varchar(100) ,
 `isArchived` tinyint(1) 
)*/;

/*Table structure for table `view_printorderproducts` */

DROP TABLE IF EXISTS `view_printorderproducts`;

/*!50001 DROP VIEW IF EXISTS `view_printorderproducts` */;
/*!50001 DROP TABLE IF EXISTS `view_printorderproducts` */;

/*!50001 CREATE TABLE  `view_printorderproducts`(
 `orderID` int(11) ,
 `orderDate` datetime ,
 `totalAmount` decimal(10,2) ,
 `orderedBy` varchar(255) ,
 `supplierName` varchar(255) ,
 `itemID` int(11) ,
 `productID` int(11) ,
 `sProductID` int(11) ,
 `productName` varchar(255) ,
 `category` varchar(100) ,
 `quantity` int(11) ,
 `product_price` decimal(10,2) ,
 `subtotal` decimal(20,2) 
)*/;

/*Table structure for table `view_product_sales` */

DROP TABLE IF EXISTS `view_product_sales`;

/*!50001 DROP VIEW IF EXISTS `view_product_sales` */;
/*!50001 DROP TABLE IF EXISTS `view_product_sales` */;

/*!50001 CREATE TABLE  `view_product_sales`(
 `productID` int(11) ,
 `productName` varchar(255) ,
 `totalQuantitySold` decimal(32,0) ,
 `totalSalesAmount` decimal(32,2) ,
 `transactionDate` date 
)*/;

/*Table structure for table `vw_checkup_report` */

DROP TABLE IF EXISTS `vw_checkup_report`;

/*!50001 DROP VIEW IF EXISTS `vw_checkup_report` */;
/*!50001 DROP TABLE IF EXISTS `vw_checkup_report` */;

/*!50001 CREATE TABLE  `vw_checkup_report`(
 `checkupID` int(11) ,
 `patientID` int(11) ,
 `checkupDate` date ,
 `remarks` text ,
 `sphereOD` varchar(10) ,
 `sphereOS` varchar(10) ,
 `cylinderOD` varchar(10) ,
 `cylinderOS` varchar(10) ,
 `axisOD` varchar(10) ,
 `axisOS` varchar(10) ,
 `addOD` varchar(10) ,
 `addOS` varchar(10) ,
 `pdOD` varchar(10) ,
 `pdOS` varchar(10) ,
 `pdOU` varchar(10) ,
 `appointmentDate` date ,
 `appointedDoctor` varchar(255) ,
 `doctorFullName` varchar(302) ,
 `patientFullName` varchar(62) 
)*/;

/*View structure for view db_viewannualsales */

/*!50001 DROP TABLE IF EXISTS `db_viewannualsales` */;
/*!50001 DROP VIEW IF EXISTS `db_viewannualsales` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewannualsales` AS select `m`.`MonthNumber` AS `MonthNumber`,`m`.`MonthName` AS `MonthName`,coalesce(sum(`t`.`totalAmount`),0) AS `TotalSales`,year(curdate()) AS `Year` from ((select 1 AS `MonthNumber`,'January' AS `MonthName` union all select 2 AS `2`,'February' AS `February` union all select 3 AS `3`,'March' AS `March` union all select 4 AS `4`,'April' AS `April` union all select 5 AS `5`,'May' AS `May` union all select 6 AS `6`,'June' AS `June` union all select 7 AS `7`,'July' AS `July` union all select 8 AS `8`,'August' AS `August` union all select 9 AS `9`,'September' AS `September` union all select 10 AS `10`,'October' AS `October` union all select 11 AS `11`,'November' AS `November` union all select 12 AS `12`,'December' AS `December`) `m` left join `tbl_transactions` `t` on(month(`t`.`transactionDate`) = `m`.`MonthNumber` and year(`t`.`transactionDate`) = year(curdate()) and `t`.`paymentStatus` = 'Paid')) group by `m`.`MonthNumber`,`m`.`MonthName` order by `m`.`MonthNumber` */;

/*View structure for view db_viewcheckup */

/*!50001 DROP TABLE IF EXISTS `db_viewcheckup` */;
/*!50001 DROP VIEW IF EXISTS `db_viewcheckup` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewcheckup` AS select `c`.`checkupID` AS `CheckupID`,`p`.`fullname` AS `PatientName`,`p`.`patientID` AS `PatientID`,`cd`.`fullname` AS `CheckupDoctor`,`ad`.`fullname` AS `AppointedDoctor`,`c`.`checkupDate` AS `CheckupDate`,`a`.`appointmentDate` AS `AppointmentDate` from ((((`tbl_checkup` `c` join `db_viewpatient` `p` on(`c`.`patientID` = `p`.`patientID`)) left join `tbl_appointments` `a` on(`c`.`checkupID` = `a`.`checkupID`)) left join `db_viewdoctors` `cd` on(`c`.`doctorID` = `cd`.`doctorID`)) left join `db_viewdoctors` `ad` on(`a`.`doctorID` = `ad`.`doctorID`)) */;

/*View structure for view db_viewcheckupdetails */

/*!50001 DROP TABLE IF EXISTS `db_viewcheckupdetails` */;
/*!50001 DROP VIEW IF EXISTS `db_viewcheckupdetails` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewcheckupdetails` AS select `c`.`checkupID` AS `CheckupID`,`p`.`fullname` AS `PatientName`,`p`.`patientID` AS `PatientID`,`d`.`fullname` AS `DoctorName`,`c`.`checkupDate` AS `CheckupDate`,`c`.`sphereOD` AS `sphereOD`,`c`.`sphereOS` AS `sphereOS`,`c`.`cylinderOD` AS `cylinderOD`,`c`.`cylinderOS` AS `cylinderOS`,`c`.`axisOD` AS `axisOD`,`c`.`axisOS` AS `axisOS`,`c`.`addOD` AS `addOD`,`c`.`addOS` AS `addOS`,`c`.`pdOD` AS `pdOD`,`c`.`pdOS` AS `pdOS`,`c`.`pdOU` AS `pdOU`,`c`.`remarks` AS `remarks` from ((`tbl_checkup` `c` join `db_viewpatient` `p` on(`c`.`patientID` = `p`.`patientID`)) join `db_viewdoctors` `d` on(`c`.`doctorID` = `d`.`doctorID`)) */;

/*View structure for view db_viewcriticalstocks */

/*!50001 DROP TABLE IF EXISTS `db_viewcriticalstocks` */;
/*!50001 DROP VIEW IF EXISTS `db_viewcriticalstocks` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewcriticalstocks` AS select `p`.`productID` AS `ProductID`,`p`.`productName` AS `ProductName`,`p`.`category` AS `Category`,`p`.`stockQuantity` AS `StockQuantity`,`p`.`reorderLevel` AS `ReorderLevel`,`p`.`unitPrice` AS `UnitPrice` from `tbl_products` `p` where `p`.`stockQuantity` <= `p`.`reorderLevel` order by `p`.`productName` */;

/*View structure for view db_viewdoctors */

/*!50001 DROP TABLE IF EXISTS `db_viewdoctors` */;
/*!50001 DROP VIEW IF EXISTS `db_viewdoctors` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewdoctors` AS select `tbl_doctor`.`doctorID` AS `doctorID`,concat(`tbl_doctor`.`fName`,' ',case when `tbl_doctor`.`mName` = 'N/A' then '' else concat(`tbl_doctor`.`mName`,' ') end,`tbl_doctor`.`lName`) AS `fullname`,`tbl_doctor`.`dob` AS `dob`,`tbl_doctor`.`contactNumber` AS `contactNumber`,`tbl_doctor`.`email` AS `email`,`tbl_doctor`.`dateAdded` AS `dateAdded` from `tbl_doctor` */;

/*View structure for view db_viewinventory */

/*!50001 DROP TABLE IF EXISTS `db_viewinventory` */;
/*!50001 DROP VIEW IF EXISTS `db_viewinventory` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewinventory` AS select `p`.`productID` AS `productID`,`p`.`productName` AS `productName`,`p`.`category` AS `category`,`p`.`stockQuantity` AS `stockQuantity`,`p`.`unitPrice` AS `unitPrice`,`p`.`description` AS `description`,`p`.`reorderLevel` AS `reorderLevel`,`p`.`dateAdded` AS `dateAdded`,`s`.`supplierName` AS `supplierName` from (`tbl_products` `p` left join `tbl_suppliers` `s` on(`p`.`supplierID` = `s`.`supplierID`)) */;

/*View structure for view db_vieworderproducts */

/*!50001 DROP TABLE IF EXISTS `db_vieworderproducts` */;
/*!50001 DROP VIEW IF EXISTS `db_vieworderproducts` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_vieworderproducts` AS select `o`.`orderID` AS `orderID`,`s`.`supplierName` AS `supplierName`,`o`.`orderDate` AS `orderDate`,`o`.`totalAmount` AS `totalAmount`,`o`.`status` AS `status`,`o`.`orderedBy` AS `orderedBy` from (`tbl_productorders` `o` join `tbl_suppliers` `s` on(`o`.`supplierID` = `s`.`supplierID`)) order by `o`.`orderDate` desc */;

/*View structure for view db_viewpatient */

/*!50001 DROP TABLE IF EXISTS `db_viewpatient` */;
/*!50001 DROP VIEW IF EXISTS `db_viewpatient` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewpatient` AS select `patient_data`.`patientID` AS `patientID`,concat(`patient_data`.`fname`,' ',case when `patient_data`.`mname` = 'N/A' then '' else concat(`patient_data`.`mname`,' ') end,`patient_data`.`lname`) AS `fullname`,timestampdiff(YEAR,`patient_data`.`bday`,curdate()) AS `age`,`patient_data`.`gender` AS `gender`,`patient_data`.`bday` AS `bday`,concat(`patient_data`.`street`,', ',`patient_data`.`brgy`,', ',`patient_data`.`city`,', ',`patient_data`.`province`,', ',`patient_data`.`region`) AS `address`,`patient_data`.`mobilenum` AS `mobilenum`,`patient_data`.`date` AS `date` from `patient_data` */;

/*View structure for view db_viewpatientsearch */

/*!50001 DROP TABLE IF EXISTS `db_viewpatientsearch` */;
/*!50001 DROP VIEW IF EXISTS `db_viewpatientsearch` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewpatientsearch` AS select `patient_data`.`patientID` AS `patientID`,concat(`patient_data`.`fname`,' ',case when `patient_data`.`mname` is null or `patient_data`.`mname` = 'N/A' then '' else concat(`patient_data`.`mname`,' ') end,`patient_data`.`lname`) AS `fullname`,`patient_data`.`bday` AS `bday` from `patient_data` */;

/*View structure for view db_viewproductsearch */

/*!50001 DROP TABLE IF EXISTS `db_viewproductsearch` */;
/*!50001 DROP VIEW IF EXISTS `db_viewproductsearch` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewproductsearch` AS select `tbl_products`.`productID` AS `productID`,`tbl_products`.`productName` AS `productName`,`tbl_products`.`category` AS `category`,`tbl_products`.`unitPrice` AS `unitPrice`,`tbl_products`.`description` AS `description` from `tbl_products` */;

/*View structure for view db_viewsalesreport */

/*!50001 DROP TABLE IF EXISTS `db_viewsalesreport` */;
/*!50001 DROP VIEW IF EXISTS `db_viewsalesreport` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewsalesreport` AS select `p`.`productID` AS `productID`,`p`.`productName` AS `productName`,`p`.`category` AS `category`,`p`.`unitPrice` AS `unitPrice`,cast(`ti`.`createdAt` as date) AS `TransactionDate`,ifnull(sum(`ti`.`quantity`),0) AS `QuantitySold`,ifnull(sum(`ti`.`quantity` * `ti`.`unitPrice`),0) AS `TotalSales` from ((`tbl_products` `p` join `tbl_transaction_items` `ti` on(`p`.`productID` = `ti`.`productID`)) join `tbl_transactions` `t` on(`ti`.`transactionID` = `t`.`transactionID`)) where `ti`.`createdAt` is not null group by `p`.`productID`,`p`.`productName`,`p`.`category`,`p`.`unitPrice`,cast(`ti`.`createdAt` as date) order by cast(`ti`.`createdAt` as date) desc */;

/*View structure for view db_viewstock */

/*!50001 DROP TABLE IF EXISTS `db_viewstock` */;
/*!50001 DROP VIEW IF EXISTS `db_viewstock` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewstock` AS select `tbl_stock_in`.`stockInID` AS `stockInID`,`tbl_products`.`productName` AS `productName`,`tbl_stock_in`.`quantityReceived` AS `quantityReceived`,`tbl_stock_in`.`costPerItem` AS `costPerItem`,`tbl_stock_in`.`totalCost` AS `totalCost`,`tbl_stock_in`.`dateReceived` AS `dateReceived`,`tbl_stock_in`.`receivedBy` AS `receivedBy` from (`tbl_stock_in` join `tbl_products` on(`tbl_stock_in`.`productID` = `tbl_products`.`productID`)) */;

/*View structure for view db_viewstockout */

/*!50001 DROP TABLE IF EXISTS `db_viewstockout` */;
/*!50001 DROP VIEW IF EXISTS `db_viewstockout` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewstockout` AS select `tbl_stock_out`.`stockOutID` AS `stockOutID`,`tbl_products`.`productName` AS `productName`,`tbl_stock_out`.`quantityIssued` AS `quantityIssued`,`tbl_stock_out`.`costPerItem` AS `costPerItem`,`tbl_stock_out`.`totalCost` AS `totalCost`,`tbl_stock_out`.`Reason` AS `Reason`,`tbl_stock_out`.`IssuedBy` AS `IssuedBy`,`tbl_stock_out`.`DateIssued` AS `DateIssued` from (`tbl_stock_out` join `tbl_products` on(`tbl_stock_out`.`productID` = `tbl_products`.`productID`)) */;

/*View structure for view db_viewtransactiondata */

/*!50001 DROP TABLE IF EXISTS `db_viewtransactiondata` */;
/*!50001 DROP VIEW IF EXISTS `db_viewtransactiondata` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewtransactiondata` AS select `t`.`transactionID` AS `transactionID`,`t`.`patientID` AS `patientID`,concat(case when `p`.`fname` = 'N/A' then '' else `p`.`fname` end,' ',case when `p`.`mname` = 'N/A' then '' else `p`.`mname` end,' ',case when `p`.`lname` = 'N/A' then '' else `p`.`lname` end) AS `patientName`,`t`.`totalAmount` AS `totalPayment`,`t`.`amountPaid` AS `amountPaid`,case when `t`.`paymentType` = 'N/A' then '' else `t`.`paymentType` end AS `typeOfPayment`,`t`.`transactionDate` AS `date`,`t`.`pendingBalance` AS `pendingBalance`,`t`.`paymentStatus` AS `paymentStatus` from (`tbl_transactions` `t` join `patient_data` `p` on(`t`.`patientID` = `p`.`patientID`)) */;

/*View structure for view db_viewuser */

/*!50001 DROP TABLE IF EXISTS `db_viewuser` */;
/*!50001 DROP VIEW IF EXISTS `db_viewuser` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `db_viewuser` AS select `tbl_users`.`UserID` AS `UserID`,`tbl_users`.`Username` AS `Username`,concat(`tbl_users`.`Fname`,' ',case when `tbl_users`.`Mname` = 'N/A' then '' else concat(`tbl_users`.`Mname`,' ') end,`tbl_users`.`Lname`) AS `fullname`,`tbl_users`.`Role` AS `Role`,`tbl_users`.`MobileNum` AS `MobileNum`,`tbl_users`.`Email` AS `Email`,`tbl_users`.`isArchived` AS `isArchived` from `tbl_users` */;

/*View structure for view view_printorderproducts */

/*!50001 DROP TABLE IF EXISTS `view_printorderproducts` */;
/*!50001 DROP VIEW IF EXISTS `view_printorderproducts` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_printorderproducts` AS select `po`.`orderID` AS `orderID`,`po`.`orderDate` AS `orderDate`,`po`.`totalAmount` AS `totalAmount`,`po`.`orderedBy` AS `orderedBy`,`s`.`supplierName` AS `supplierName`,`poi`.`itemID` AS `itemID`,`poi`.`productID` AS `productID`,`sp`.`sProductID` AS `sProductID`,coalesce(`poi`.`productName`,`sp`.`product_name`) AS `productName`,coalesce(`sp`.`category`,'N/A') AS `category`,`poi`.`quantity` AS `quantity`,coalesce(`sp`.`product_price`,0) AS `product_price`,`poi`.`quantity` * coalesce(`sp`.`product_price`,0) AS `subtotal` from (((`tbl_productorders` `po` left join `tbl_suppliers` `s` on(`po`.`supplierID` = `s`.`supplierID`)) left join `tbl_productorder_items` `poi` on(`po`.`orderID` = `poi`.`orderID`)) left join `tbl_supplier_products` `sp` on(`poi`.`productName` = `sp`.`product_name` and `po`.`supplierID` = `sp`.`supplierID`)) order by `po`.`orderID` desc */;

/*View structure for view view_product_sales */

/*!50001 DROP TABLE IF EXISTS `view_product_sales` */;
/*!50001 DROP VIEW IF EXISTS `view_product_sales` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_product_sales` AS select `ti`.`productID` AS `productID`,`ti`.`productName` AS `productName`,sum(`ti`.`quantity`) AS `totalQuantitySold`,sum(`ti`.`totalPrice`) AS `totalSalesAmount`,`t`.`transactionDate` AS `transactionDate` from (`tbl_transaction_items` `ti` join `tbl_transactions` `t` on(`ti`.`transactionID` = `t`.`transactionID`)) group by `ti`.`productID`,`ti`.`productName`,`t`.`transactionDate` order by `t`.`transactionDate` desc */;

/*View structure for view vw_checkup_report */

/*!50001 DROP TABLE IF EXISTS `vw_checkup_report` */;
/*!50001 DROP VIEW IF EXISTS `vw_checkup_report` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vw_checkup_report` AS select `c`.`checkupID` AS `checkupID`,`c`.`patientID` AS `patientID`,`c`.`checkupDate` AS `checkupDate`,`c`.`remarks` AS `remarks`,`c`.`sphereOD` AS `sphereOD`,`c`.`sphereOS` AS `sphereOS`,`c`.`cylinderOD` AS `cylinderOD`,`c`.`cylinderOS` AS `cylinderOS`,`c`.`axisOD` AS `axisOD`,`c`.`axisOS` AS `axisOS`,`c`.`addOD` AS `addOD`,`c`.`addOS` AS `addOS`,`c`.`pdOD` AS `pdOD`,`c`.`pdOS` AS `pdOS`,`c`.`pdOU` AS `pdOU`,`c`.`appointmentDate` AS `appointmentDate`,`c`.`appointedDoctor` AS `appointedDoctor`,concat(case when `d`.`fName` <> 'N/A' then `d`.`fName` else '' end,case when `d`.`mName` <> 'N/A' and `d`.`mName` <> '' then concat(' ',`d`.`mName`) else '' end,case when `d`.`lName` <> 'N/A' then concat(' ',`d`.`lName`) else '' end) AS `doctorFullName`,concat(case when `p`.`fname` <> 'N/A' then `p`.`fname` else '' end,case when `p`.`mname` <> 'N/A' and `p`.`mname` <> '' then concat(' ',`p`.`mname`) else '' end,case when `p`.`lname` <> 'N/A' then concat(' ',`p`.`lname`) else '' end) AS `patientFullName` from ((`tbl_checkup` `c` left join `tbl_doctor` `d` on(`c`.`doctorID` = `d`.`doctorID`)) left join `patient_data` `p` on(`c`.`patientID` = `p`.`patientID`)) */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
