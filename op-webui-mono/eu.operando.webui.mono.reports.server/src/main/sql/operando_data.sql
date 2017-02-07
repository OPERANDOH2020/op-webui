-- phpMyAdmin SQL Dump
-- version 4.0.10.10
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generato il: Dic 05, 2016 alle 15:11
-- Versione del server: 5.1.73
-- Versione PHP: 5.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `operando_data`
--
CREATE DATABASE IF NOT EXISTS `operando_data` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `operando_data`;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_gambling_diseases`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_gambling_diseases`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_gambling_diseases` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `typeofrelateddiseases` varchar(200) NOT NULL,
  `intheuseofalcohol` tinyint(1) NOT NULL,
  `intheuseoftobacco` tinyint(1) NOT NULL,
  `intheuseofdrug` tinyint(1) NOT NULL,
  `patient` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=18 ;

--
-- Dump dei dati per la tabella `t_data_aslbergamo_gambling_diseases`
--

INSERT INTO `t_data_aslbergamo_gambling_diseases` (`ID`, `typeofrelateddiseases`, `intheuseofalcohol`, `intheuseoftobacco`, `intheuseofdrug`, `patient`) VALUES
(1, 'cirrhosis\r\n', 1, 1, 1, 1),
(2, 'ulcerative-colitis', 1, 0, 0, 7),
(3, 'cirrhosis\r\n', 1, 1, 1, 3),
(4, 'ulcerative-colitis', 0, 0, 1, 3),
(5, 'ulcerative-colitis', 0, 0, 1, 4),
(6, 'cirrhosis\r\n', 1, 1, 1, 4),
(7, 'AIDS\r\n', 1, 1, 1, 4),
(8, 'AIDS', 0, 0, 1, 6),
(9, 'Obesity and Overweight', 1, 1, 1, 4),
(10, 'Obesity and Overweight', 0, 0, 1, 2),
(11, 'Obesity and Overweight', 1, 0, 0, 7),
(12, 'Gonorrhea', 0, 0, 1, 6),
(13, 'Obesity and Overweight', 0, 0, 1, 6),
(14, 'Obesity and Overweight', 1, 1, 1, 5),
(15, 'Gonorrhea', 1, 1, 1, 5),
(16, 'cirrhosis\r\n', 1, 1, 1, 5),
(17, 'ulcerative-colitis', 1, 1, 1, 5);

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_gambling_pathology`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_gambling_pathology`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_gambling_pathology` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `monthly amount` int(11) NOT NULL,
  `place` varchar(200) NOT NULL,
  `when` varchar(200) NOT NULL,
  `type` varchar(200) NOT NULL,
  `alcoholwhile` tinyint(1) NOT NULL,
  `tobaccowhile` tinyint(1) NOT NULL,
  `drugwhile` tinyint(1) NOT NULL,
  `yearsofearlydisease` int(11) NOT NULL,
  `patient` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Dump dei dati per la tabella `t_data_aslbergamo_gambling_pathology`
--

INSERT INTO `t_data_aslbergamo_gambling_pathology` (`ID`, `monthly amount`, `place`, `when`, `type`, `alcoholwhile`, `tobaccowhile`, `drugwhile`, `yearsofearlydisease`, `patient`) VALUES
(1, 500, 'bar', 'evening', 'slot machine', 1, 0, 0, 14, 1),
(2, 20, 'bar', 'night', 'party', 0, 0, 1, 16, 2),
(3, 300, 'bar', 'morning', 'slot machine', 1, 0, 0, 17, 2),
(4, 300, 'pub', 'evening', 'cards', 1, 0, 0, 25, 3),
(5, 43, 'bar', 'night', 'party', 0, 0, 1, 16, 3),
(6, 30, 'bar', 'night', 'party', 1, 1, 1, 16, 4),
(7, 60, 'bar', 'evening', 'slot machine', 1, 1, 1, 13, 4),
(8, 60, 'bar', 'evening', 'slot machine', 0, 0, 1, 13, 6),
(9, 300, 'bar', 'morning', 'slot machine', 1, 0, 0, 17, 7),
(10, 43, 'bar', 'night', 'party', 0, 0, 1, 16, 6),
(11, 20, 'house', 'afternoon', 'none', 1, 0, 0, 16, 7),
(12, 20, 'house', 'afternoon', 'none', 1, 1, 1, 18, 5),
(13, 26, 'bar', 'night', 'party', 1, 1, 1, 13, 5),
(14, 6, 'pub', 'evening', 'cards', 1, 1, 1, 13, 5);

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_gambling_patient`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_gambling_patient`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_gambling_patient` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(200) NOT NULL,
  `surname` varchar(200) NOT NULL,
  `sex` varchar(200) NOT NULL,
  `dateofbirth` date NOT NULL,
  `placeofbirth` varchar(200) NOT NULL,
  `cityofresidence` varchar(200) NOT NULL,
  `e-mailaddress` varchar(200) NOT NULL,
  `cellphonenumber` varchar(200) NOT NULL,
  `debt` tinyint(1) NOT NULL,
  `debtduetoplay` tinyint(1) NOT NULL,
  `alcoholuse` tinyint(1) NOT NULL,
  `tobaccouse` tinyint(1) NOT NULL,
  `druguse` tinyint(1) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dump dei dati per la tabella `t_data_aslbergamo_gambling_patient`
--

INSERT INTO `t_data_aslbergamo_gambling_patient` (`ID`, `name`, `surname`, `sex`, `dateofbirth`, `placeofbirth`, `cityofresidence`, `e-mailaddress`, `cellphonenumber`, `debt`, `debtduetoplay`, `alcoholuse`, `tobaccouse`, `druguse`) VALUES
(1, 'Luigi', 'Clivati', 'M', '1983-09-25', 'Gazzaniga', 'Bologna', 'luigi@email.it', '3476545454', 1, 0, 1, 0, 0),
(2, 'Daniele', 'Del Rio', 'M', '1973-09-25', 'Bologna', 'Canelli', 'mymailismycity@email.it', '321458569', 0, 1, 0, 0, 1),
(3, 'Fabiola', 'Caffagni', 'F', '1956-09-25', 'Milano', 'Venezia', 'maimail@email.uk', '3329654785', 1, 0, 1, 0, 0),
(4, 'Dimitri', 'Zakharova', 'M', '1986-09-25', 'Ekaterinburg', 'Ufa', 'maimail@email.ru', '3329654785', 1, 1, 1, 1, 1),
(7, 'Marcella', 'Di Francesco', 'F', '1972-09-25', 'Bari', 'Maglie', 'lamiamail@email.it', '3291452587', 0, 0, 1, 1, 0),
(6, 'Anthony', 'Robinson', 'M', '1962-09-25', 'Boston', 'Miami', 'maimail@email.us', '365745865', 0, 0, 0, 1, 1),
(5, 'Abby', 'EVANS', 'F', '1977-09-25', 'Liverpool', 'Brighton', 'maimail@email.uk', '365745865', 0, 0, 1, 1, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_psw_agenda`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_psw_agenda`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_psw_agenda` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `nextinspection` tinyint(1) NOT NULL,
  `whendate` date NOT NULL,
  `whentimebegin` int(11) NOT NULL,
  `officerID` varchar(200) NOT NULL,
  `officername` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_psw_inspection`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_psw_inspection`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_psw_inspection` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `who` varchar(200) NOT NULL,
  `placecity` varchar(200) NOT NULL,
  `placeaddress` varchar(200) NOT NULL,
  `placestreetnumber` varchar(200) NOT NULL,
  `placepostalcode` varchar(200) NOT NULL,
  `whendate` varchar(200) NOT NULL,
  `whentimebegin` varchar(200) NOT NULL,
  `whentimeend` varchar(200) NOT NULL,
  `penaltiesinflicted` tinyint(1) NOT NULL,
  `officerID` varchar(200) NOT NULL,
  `officername` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_psw_payment`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_psw_payment`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_psw_payment` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `total` tinyint(1) NOT NULL,
  `date` date NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_psw_penalty`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_psw_penalty`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_psw_penalty` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `amount` decimal(18,2) NOT NULL,
  `reason` varchar(200) NOT NULL,
  `dangerlevel` int(11) NOT NULL,
  `firstpenalty` tinyint(1) NOT NULL,
  `paymentdone` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_aslbergamo_psw_report`
--

DROP TABLE IF EXISTS `t_data_aslbergamo_psw_report`;
CREATE TABLE IF NOT EXISTS `t_data_aslbergamo_psw_report` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `uploadv` blob NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_gaslini_consent`
--

DROP TABLE IF EXISTS `t_data_gaslini_consent`;
CREATE TABLE IF NOT EXISTS `t_data_gaslini_consent` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `variousconsent` tinyint(1) NOT NULL,
  `variousconsent2` tinyint(1) NOT NULL,
  `variousconsent3` tinyint(1) NOT NULL,
  `variousconsent4` tinyint(1) NOT NULL,
  `variousconsent5` tinyint(1) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_gaslini_doctor`
--

DROP TABLE IF EXISTS `t_data_gaslini_doctor`;
CREATE TABLE IF NOT EXISTS `t_data_gaslini_doctor` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `name` varchar(200) NOT NULL,
  `surname` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_gaslini_document`
--

DROP TABLE IF EXISTS `t_data_gaslini_document`;
CREATE TABLE IF NOT EXISTS `t_data_gaslini_document` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `upload` blob NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_gaslini_patient`
--

DROP TABLE IF EXISTS `t_data_gaslini_patient`;
CREATE TABLE IF NOT EXISTS `t_data_gaslini_patient` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `name` varchar(200) NOT NULL,
  `surname` varchar(200) NOT NULL,
  `sex` varchar(200) NOT NULL,
  `dateofbirth` date NOT NULL,
  `placeofbirth` varchar(200) NOT NULL,
  `provinceofbirth` varchar(200) NOT NULL,
  `residencecity` varchar(200) NOT NULL,
  `residencestreet` varchar(200) NOT NULL,
  `residencestnumb` varchar(200) NOT NULL,
  `residencepostcode` varchar(200) NOT NULL,
  `e-mailaddress` varchar(200) NOT NULL,
  `cellphonenumber` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struttura della tabella `t_data_gaslini_patient_lp`
--

DROP TABLE IF EXISTS `t_data_gaslini_patient_lp`;
CREATE TABLE IF NOT EXISTS `t_data_gaslini_patient_lp` (
  `ID` int(11) NOT NULL DEFAULT '0',
  `typeoflegal` varchar(200) NOT NULL,
  `legalname` varchar(200) NOT NULL,
  `legalsurname` varchar(200) NOT NULL,
  `legaldateofbirth` date NOT NULL,
  `legalplaceofbirth` varchar(200) NOT NULL,
  `legalprovinceofbirth` varchar(200) NOT NULL,
  `legalresidencecity` varchar(200) NOT NULL,
  `legalresstreet` varchar(200) NOT NULL,
  `legalresstnumb` varchar(200) NOT NULL,
  `leaglrespostcode` varchar(200) NOT NULL,
  `legale-mailaddress` varchar(200) NOT NULL,
  `legalcellphonenumber` varchar(200) NOT NULL,
  `minorname` varchar(200) NOT NULL,
  `minorsurname` varchar(200) NOT NULL,
  `minordateofbirth` varchar(200) NOT NULL,
  `minorplaceofbirth` varchar(200) NOT NULL,
  `minorprovincebirth` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
