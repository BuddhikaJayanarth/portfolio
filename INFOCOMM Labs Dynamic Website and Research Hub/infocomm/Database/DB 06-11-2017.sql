-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 06, 2017 at 09:15 AM
-- Server version: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `infocomm`
--

-- --------------------------------------------------------

--
-- Table structure for table `about`
--

CREATE TABLE IF NOT EXISTS `about` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `col1` text NOT NULL,
  `col2` text NOT NULL,
  `col3` text NOT NULL,
  `img1` varchar(255) NOT NULL,
  `img2` varchar(255) NOT NULL,
  `img3` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `about`
--

INSERT INTO `about` (`ID`, `col1`, `col2`, `col3`, `img1`, `img2`, `img3`) VALUES
(1, 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'http://localhost/infocomm/resources/about/img1.jpg', 'http://localhost/infocomm/resources/about/img2.jpg', 'http://localhost/infocomm/resources/about/img3.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `categories_project`
--

CREATE TABLE IF NOT EXISTS `categories_project` (
  `catID` int(11) NOT NULL AUTO_INCREMENT,
  `catName` varchar(255) NOT NULL,
  PRIMARY KEY (`catID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=27 ;

--
-- Dumping data for table `categories_project`
--

INSERT INTO `categories_project` (`catID`, `catName`) VALUES
(1, 'Cooperative Relay Communications'),
(2, 'Space time block coding and MIMO'),
(3, 'Wireless Energy Harvesting in Wireless Networks'),
(4, 'LDPC/LDLC Codes'),
(5, '5G Communications Technologies (NOMA and Massive MIMO)'),
(6, 'Full Duplex Radio Communications'),
(7, 'Device to Device Communications'),
(8, 'OFDMA/OFDM'),
(9, 'Engineering Education'),
(21, 'uncategorized'),
(22, 'uncategorized'),
(23, 'uncategorized'),
(24, 'uncategorized'),
(25, 'uncategorized'),
(26, 'uncategorized');

-- --------------------------------------------------------

--
-- Table structure for table `collaborators`
--

CREATE TABLE IF NOT EXISTS `collaborators` (
  `collaboratorID` int(11) NOT NULL AUTO_INCREMENT,
  `affiliation` varchar(255) NOT NULL,
  `department` varchar(255) NOT NULL,
  `contactPerson` varchar(255) NOT NULL,
  `website` varchar(255) NOT NULL,
  `logo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`collaboratorID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `collaborators`
--

INSERT INTO `collaborators` (`collaboratorID`, `affiliation`, `department`, `contactPerson`, `website`, `logo`) VALUES
(1, 'Ruissa University', 'Teaching', 'James Nelson Jr Jr Jr', 'wwww.russiauni.com', 'null'),
(3, 'China University', 'Science', 'James', 'www.chinauni.com', 'defaultcollabimage.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `contact`
--

CREATE TABLE IF NOT EXISTS `contact` (
  `key` int(1) NOT NULL,
  `contactheader` varchar(255) NOT NULL,
  `contactbody` varchar(500) NOT NULL,
  `address` varchar(1000) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `email` varchar(30) NOT NULL,
  `xcoordinate` double NOT NULL,
  `ycoordinate` double NOT NULL,
  PRIMARY KEY (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contact`
--

INSERT INTO `contact` (`key`, `contactheader`, `contactbody`, `address`, `phone`, `email`, `xcoordinate`, `ycoordinate`) VALUES
(1, 'Please fill in the form to contact us.', 'If you have any questions or queries simply leave us a message and we will get back to you at our earliest. Thank you.', '21 Jump Streets\r\nSomewhere, Someplace', '+1 555 123456', 'contact@infocomm.com', 56.4656735, 84.947323);

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE IF NOT EXISTS `events` (
  `eventID` int(11) NOT NULL AUTO_INCREMENT,
  `eventName` varchar(255) NOT NULL,
  `date` date NOT NULL,
  `eventTime` time NOT NULL,
  `duration` int(11) NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `description` text,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`eventID`),
  KEY `adminID` (`userID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=33 ;

--
-- Dumping data for table `events`
--

INSERT INTO `events` (`eventID`, `eventName`, `date`, `eventTime`, `duration`, `location`, `description`, `userID`) VALUES
(1, 'Party', '2017-07-25', '19:00:00', 3, 'Home', 'Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party ', 0),
(2, 'Party 2', '2017-01-25', '09:00:00', 1, '23 Avenue, Goldberg Place, New Land', 'Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party Party ', 0),
(31, 'Movie Night', '2017-12-08', '06:45:00', 5, 'Office Lab 3', '<p>We will be playing a movie</p>\r\n\r\n<ul>\r\n	<li>Frankenstien</li>\r\n	<li>Avengers</li>\r\n	<li>Science Man</li>\r\n</ul>\r\n', 0),
(32, 'Conference on Technology', '2018-10-25', '10:45:00', 6, '9th Floor Board Room', '<p>This is a conference for all technology enthusiasts.</p>\r\n\r\n<p>It is open to the public</p>\r\n\r\n<p><var>Topics that will be covered:</var></p>\r\n\r\n<ul>\r\n	<li>Biotechnology</li>\r\n	<li>Nanotechnology</li>\r\n	<li>Green tech</li>\r\n</ul>\r\n', 0);

-- --------------------------------------------------------

--
-- Table structure for table `event_media`
--

CREATE TABLE IF NOT EXISTS `event_media` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `eventID` int(11) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `link` (`link`),
  KEY `eventID` (`eventID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `follows`
--

CREATE TABLE IF NOT EXISTS `follows` (
  `userID` int(100) NOT NULL,
  `following` int(10) NOT NULL,
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `follows`
--

INSERT INTO `follows` (`userID`, `following`) VALUES
(1, 3),
(1, 4),
(1, 2),
(2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `funders`
--

CREATE TABLE IF NOT EXISTS `funders` (
  `FunderName` varchar(255) NOT NULL,
  `imgPath` varchar(500) NOT NULL,
  PRIMARY KEY (`FunderName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `funders`
--

INSERT INTO `funders` (`FunderName`, `imgPath`) VALUES
('Inogen Studios', 'null'),
('Yani Rex Ltd.', 'null');

-- --------------------------------------------------------

--
-- Table structure for table `news`
--

CREATE TABLE IF NOT EXISTS `news` (
  `newsID` int(11) NOT NULL AUTO_INCREMENT,
  `headline` varchar(255) NOT NULL,
  `subHeadline` varchar(255) DEFAULT NULL,
  `text` text,
  `date` date NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`newsID`),
  KEY `adminID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `news_media`
--

CREATE TABLE IF NOT EXISTS `news_media` (
  `newsID` int(11) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`newsID`,`link`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `positions`
--

CREATE TABLE IF NOT EXISTS `positions` (
  `designation` varchar(255) NOT NULL DEFAULT '',
  `shownInOurteam` int(10) DEFAULT '-1',
  PRIMARY KEY (`designation`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `positions`
--

INSERT INTO `positions` (`designation`, `shownInOurteam`) VALUES
('Engineer', -1),
('Head Lab Supervisor', 1),
('Lab Supervisor', 2),
('Researcher', 0);

-- --------------------------------------------------------

--
-- Table structure for table `post_comments`
--

CREATE TABLE IF NOT EXISTS `post_comments` (
  `commentID` int(11) NOT NULL AUTO_INCREMENT,
  `postID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `text` text,
  `dateTime` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`commentID`),
  KEY `userID` (`userID`),
  KEY `postID` (`postID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `project_collaborators`
--

CREATE TABLE IF NOT EXISTS `project_collaborators` (
  `projectID` varchar(255) NOT NULL,
  `collabID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`collabID`),
  KEY `collabID` (`collabID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_collaborators`
--

INSERT INTO `project_collaborators` (`projectID`, `collabID`) VALUES
('2', 3);

-- --------------------------------------------------------

--
-- Table structure for table `project_events`
--

CREATE TABLE IF NOT EXISTS `project_events` (
  `pid` varchar(255) NOT NULL,
  `eid` int(11) NOT NULL,
  PRIMARY KEY (`pid`,`eid`),
  KEY `fkprojecteventseid` (`eid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_events`
--

INSERT INTO `project_events` (`pid`, `eid`) VALUES
('2', 1),
('2', 2),
('2', 32);

-- --------------------------------------------------------

--
-- Table structure for table `project_followers`
--

CREATE TABLE IF NOT EXISTS `project_followers` (
  `projectID` varchar(255) NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_followers`
--

INSERT INTO `project_followers` (`projectID`, `userID`) VALUES
('1', 1),
('2', 1),
('2', 3),
('2', 4);

-- --------------------------------------------------------

--
-- Table structure for table `project_funders`
--

CREATE TABLE IF NOT EXISTS `project_funders` (
  `projectID` varchar(255) NOT NULL,
  `funderName` varchar(255) NOT NULL,
  PRIMARY KEY (`projectID`,`funderName`),
  KEY `funderName` (`funderName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_funders`
--

INSERT INTO `project_funders` (`projectID`, `funderName`) VALUES
('2', 'Inogen Studios'),
('2', 'Yani Rex Ltd.');

-- --------------------------------------------------------

--
-- Table structure for table `project_members`
--

CREATE TABLE IF NOT EXISTS `project_members` (
  `projectID` varchar(255) NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_members`
--

INSERT INTO `project_members` (`projectID`, `userID`) VALUES
('2', 1),
('2', 6);

-- --------------------------------------------------------

--
-- Table structure for table `project_posts`
--

CREATE TABLE IF NOT EXISTS `project_posts` (
  `upID` int(100) NOT NULL AUTO_INCREMENT,
  `pID` varchar(255) NOT NULL,
  `updescription` text NOT NULL,
  `uplink` text,
  `postLikes` int(100) DEFAULT '0',
  `updatetime` datetime NOT NULL,
  PRIMARY KEY (`upID`),
  KEY `project_posts_ibfk_1` (`pID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `project_posts`
--

INSERT INTO `project_posts` (`upID`, `pID`, `updescription`, `uplink`, `postLikes`, `updatetime`) VALUES
(1, '2', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:46:50'),
(2, '2', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:47:42'),
(3, '2', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:48:29'),
(4, '2', 'orem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:49:19'),
(5, '2', 'ipsum represents', '', 0, '2017-10-12 11:01:50'),
(6, '2', 'ipsum represents', '', 0, '2017-10-27 04:51:00'),
(7, '2', 'ipsum represents', '', 0, '2017-10-27 04:57:19');

-- --------------------------------------------------------

--
-- Table structure for table `project_posts_comments`
--

CREATE TABLE IF NOT EXISTS `project_posts_comments` (
  `commentID` int(100) NOT NULL AUTO_INCREMENT,
  `upID` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `description` text NOT NULL,
  `cdatetime` datetime NOT NULL,
  PRIMARY KEY (`commentID`),
  KEY `project_posts_comments_ibfk_1` (`userID`),
  KEY `project_posts_comments_ibfk_2` (`upID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `project_posts_comments`
--

INSERT INTO `project_posts_comments` (`commentID`, `upID`, `userID`, `description`, `cdatetime`) VALUES
(1, 4, 1, 'This is a good article', '2017-10-12 11:00:47'),
(2, 4, 2, 'Hello good', '2017-10-12 11:01:01'),
(3, 3, 3, 'Nad article', '2017-10-12 11:01:25');

-- --------------------------------------------------------

--
-- Table structure for table `project_posts_old`
--

CREATE TABLE IF NOT EXISTS `project_posts_old` (
  `postID` int(11) NOT NULL AUTO_INCREMENT,
  `projectID` varchar(255) NOT NULL,
  `userID` int(11) NOT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `description` text,
  `mediaLink` varchar(255) DEFAULT NULL,
  `type` char(1) NOT NULL,
  PRIMARY KEY (`postID`),
  KEY `userID` (`userID`),
  KEY `projectID` (`projectID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `project_publications`
--

CREATE TABLE IF NOT EXISTS `project_publications` (
  `projectID` varchar(255) NOT NULL,
  `pubID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`pubID`),
  KEY `pubID` (`pubID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project_publications`
--

INSERT INTO `project_publications` (`projectID`, `pubID`) VALUES
('2', 5);

-- --------------------------------------------------------

--
-- Table structure for table `project_research`
--

CREATE TABLE IF NOT EXISTS `project_research` (
  `projectID` varchar(255) NOT NULL,
  `researchTopic` varchar(255) NOT NULL,
  PRIMARY KEY (`projectID`,`researchTopic`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reportedusers`
--

CREATE TABLE IF NOT EXISTS `reportedusers` (
  `RID` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `reason` text NOT NULL,
  PRIMARY KEY (`RID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `reportedusers`
--

INSERT INTO `reportedusers` (`RID`, `userID`, `reason`) VALUES
(3, 2, 'Very Strange user, :('),
(4, 2, 'Very bad');

-- --------------------------------------------------------

--
-- Table structure for table `securityquestion`
--

CREATE TABLE IF NOT EXISTS `securityquestion` (
  `sqID` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `question` text NOT NULL,
  `answer` text NOT NULL,
  `sqDate` date NOT NULL,
  PRIMARY KEY (`sqID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `userID` int(100) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `title` varchar(255) NOT NULL,
  `fname` varchar(255) NOT NULL,
  `lname` varchar(255) NOT NULL,
  `gender` char(1) NOT NULL,
  `dob` date NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `userType` char(1) NOT NULL,
  `designation` varchar(255) DEFAULT NULL,
  `lastLogin` datetime DEFAULT NULL,
  `dateJoined` date DEFAULT NULL,
  `accessLevel` int(10) DEFAULT '1',
  `status` varchar(100) DEFAULT 'Pending',
  `city` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `facebook` varchar(255) DEFAULT NULL,
  `googlePlus` varchar(255) DEFAULT NULL,
  `linkedIn` varchar(255) DEFAULT NULL,
  `twitter` varchar(255) DEFAULT NULL,
  `website` varchar(255) DEFAULT NULL,
  `bio` text,
  `interest` text,
  `phone` varchar(100) DEFAULT NULL,
  `activationKey` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`userID`),
  KEY `fk_pos` (`designation`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `username`, `title`, `fname`, `lname`, `gender`, `dob`, `email`, `password`, `userType`, `designation`, `lastLogin`, `dateJoined`, `accessLevel`, `status`, `city`, `country`, `facebook`, `googlePlus`, `linkedIn`, `twitter`, `website`, `bio`, `interest`, `phone`, `activationKey`) VALUES
(1, 'johnDoe', 'Prof.', 'John', 'Doe', 'M', '2017-08-08', 'john@doe.com', '$2y$12$7l.5wvT.Qdw7680tsN/ryOVnG2XZtRh6jJ97BG5BrsKRFLzDqd1Yq', 'I', 'Engineer', '2017-10-26 23:53:38', '2017-08-01', 1, 'Activated', 'Colombo', 'Sri Lanka', 'facebook.com/JohnDoe', 'google.com/JohnDoe', 'linkedIn.com/JohnDoe', 'twitter.com/JohnDoe', 'www.johndoe.com', 'Am a good good man I know it', 'Cats; Ducks; Golf', '123456789', NULL),
(2, 'jackieRiener', 'Ms.', 'Jackie', 'Riener', 'F', '1917-05-01', 'jackieriener@mail.com', '$2y$12$7l.5wvT.Qdw7680tsN/ryOVnG2XZtRh6jJ97BG5BrsKRFLzDqd1Yq', 'I', NULL, '2017-10-12 07:40:47', '2017-04-24', 3, 'Activated', 'Duck City', 'Duckland', 'facebook.com/ducky', NULL, NULL, NULL, NULL, 'Some text that describes me lorem ipsum ipsum lorem.', 'Ducks; Cats; Hockey', NULL, NULL),
(3, 'JoeDoe', 'Sir', 'Joe', 'Doe', 'M', '2017-03-14', 'joe_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Researcher', '2017-10-12 06:59:16', '2017-09-06', 3, 'Activated', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'JaneDoe', 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 1, 'Approved', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'JaneDoe22', 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane2_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Head Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 3, 'Suspended', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(6, 'maryJane', 'Prof.', 'Mary', 'Jane', 'f', '1983-09-19', 'maryjane@mail.com', '$2y$12$g/ihBBSm1ljX6x4bvlG2UuYArqGc3wmJpKvbsnT5OMetQaPHSCYVa', 'G', NULL, NULL, '0000-00-00', 4, 'Deactivated', 'New Mexico', 'USA', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user_education`
--

CREATE TABLE IF NOT EXISTS `user_education` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `institute` varchar(255) NOT NULL,
  `qualification` varchar(255) NOT NULL,
  `startDate` date NOT NULL,
  `gradDate` date NOT NULL,
  PRIMARY KEY (`id`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `user_education`
--

INSERT INTO `user_education` (`id`, `userID`, `institute`, `qualification`, `startDate`, `gradDate`) VALUES
(1, 1, 'Curtin University', 'BSc Engineering', '0000-00-00', '0000-00-00'),
(2, 1, 'Tokyo University of Arts', 'Masters in Fine Arts', '0000-00-00', '0000-00-00'),
(3, 1, 'University of Toronto', 'Phd Robotics', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `user_posts`
--

CREATE TABLE IF NOT EXISTS `user_posts` (
  `upID` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `uptype` varchar(255) NOT NULL,
  `updescription` text NOT NULL,
  `uplink` text,
  `postLikes` int(100) DEFAULT '0',
  `updatetime` datetime NOT NULL,
  PRIMARY KEY (`upID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `user_posts`
--

INSERT INTO `user_posts` (`upID`, `userID`, `uptype`, `updescription`, `uplink`, `postLikes`, `updatetime`) VALUES
(1, 1, 'userPost', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:46:50'),
(2, 4, 'userPost', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:47:42'),
(3, 2, 'userPost', 'Lorem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:48:29'),
(4, 1, 'userPost', 'orem ipsum represents a long-held tradition for designers, typographers and the like. Some people hate it and argue for its demise, but others ignore the hate as they create awesome tools to help create filler text for everyone from bacon lovers to Charlie Sheen fans.', '', 0, '2017-10-10 21:49:19'),
(5, 1, 'userPost', 'Am such a good boy', '', 0, '2017-10-12 11:01:50'),
(6, 1, 'userPost', '', '', 0, '2017-10-27 04:51:00'),
(7, 1, 'userPost', '', '', 0, '2017-10-27 04:57:19');

-- --------------------------------------------------------

--
-- Table structure for table `user_posts_comments`
--

CREATE TABLE IF NOT EXISTS `user_posts_comments` (
  `commentID` int(100) NOT NULL AUTO_INCREMENT,
  `upID` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `description` text NOT NULL,
  `cdatetime` datetime NOT NULL,
  PRIMARY KEY (`commentID`,`upID`,`userID`),
  KEY `userID` (`userID`),
  KEY `upID` (`upID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `user_posts_comments`
--

INSERT INTO `user_posts_comments` (`commentID`, `upID`, `userID`, `description`, `cdatetime`) VALUES
(6, 4, 1, 'This is a good article', '2017-10-12 11:00:47'),
(7, 4, 1, 'Hello good', '2017-10-12 11:01:01'),
(8, 3, 1, 'Nad article', '2017-10-12 11:01:25');

-- --------------------------------------------------------

--
-- Table structure for table `user_projects`
--

CREATE TABLE IF NOT EXISTS `user_projects` (
  `userID` int(11) NOT NULL,
  `projectID` varchar(255) NOT NULL,
  `catID` int(11) NOT NULL,
  `projectTitle` varchar(255) NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date DEFAULT NULL,
  `description` text,
  `imageLink` varchar(255) DEFAULT NULL,
  `dateCreated` date DEFAULT NULL,
  PRIMARY KEY (`projectID`),
  KEY `userID` (`userID`),
  KEY `FK_userCats` (`catID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_projects`
--

INSERT INTO `user_projects` (`userID`, `projectID`, `catID`, `projectTitle`, `startDate`, `endDate`, `description`, `imageLink`, `dateCreated`) VALUES
(1, '1', 1, 'One More Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubof abeo fbsknbfso piefnos fnsoaf nsoaefibnes afoia senfoea skfbn iofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, '159de11f86f4d4', 1, '', '0000-00-00', '0000-00-00', '', 'imagelink', '2017-10-11'),
(1, '159de1b6311ec8', 2, 'Image upload test', '2017-10-12', '2017-10-14', 'adfasdf', NULL, '2017-10-11'),
(1, '2', 1, 'Test Project', '2017-08-14', NULL, 'This is a project description', NULL, '2017-08-01'),
(1, '3', 1, 'Another Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, '8', 1, 'Analysing radio wave density with altitude', '2017-08-14', '0000-00-00', 'Investigating the affects of atmospheric density on radio waves', 'imagelink', '2017-09-13'),
(1, '9', 1, 'Analysing radio wave density with altitude', '2017-10-02', '2017-10-06', 'dre', 'imagelink', '2017-10-03');

-- --------------------------------------------------------

--
-- Table structure for table `user_publications`
--

CREATE TABLE IF NOT EXISTS `user_publications` (
  `pubID` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `pubTitle` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `category` int(11) DEFAULT NULL,
  `link` text NOT NULL,
  `isPublic` int(1) DEFAULT '0',
  `datePublished` date NOT NULL,
  PRIMARY KEY (`pubID`),
  KEY `userID` (`userID`),
  KEY `fk_pubCats` (`category`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `user_publications`
--

INSERT INTO `user_publications` (`pubID`, `userID`, `pubTitle`, `type`, `category`, `link`, `isPublic`, `datePublished`) VALUES
(5, 1, 'Conference on Human Genome', 'Book', 2, 'www.ieee.org/Jack/ConferenceonHumanGenome', 0, '2017-08-01'),
(6, 2, 'Resonance theory', 'book', 4, 'www.w3schools.com', 1, '2017-10-09'),
(7, 6, 'Erratic Phenol Theory', 'Conference', 3, 'www.yourhtmlsource.com', 1, '2017-10-01');

-- --------------------------------------------------------

--
-- Table structure for table `user_ri`
--

CREATE TABLE IF NOT EXISTS `user_ri` (
  `userID` int(100) NOT NULL,
  `RI` varchar(255) NOT NULL,
  PRIMARY KEY (`userID`,`RI`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_timeline`
--

CREATE TABLE IF NOT EXISTS `user_timeline` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `userID` int(100) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `activity` varchar(255) NOT NULL,
  `body` varchar(255) DEFAULT NULL,
  `dateTimeline` datetime DEFAULT NULL,
  PRIMARY KEY (`id`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `user_timeline`
--

INSERT INTO `user_timeline` (`id`, `userID`, `subject`, `activity`, `body`, `dateTimeline`) VALUES
(1, 1, 'Education', 'You updated your Education Info', 'Changes were made to institute <strong>Tokyo University of Arts</strong>', '2017-10-03 13:26:53'),
(2, 1, 'Bio', 'You updated your Bio and Interests', '', '2017-10-10 18:18:35'),
(3, 1, 'password', 'You changed your password', '', '2017-09-14 09:31:02');

-- --------------------------------------------------------

--
-- Table structure for table `user_work`
--

CREATE TABLE IF NOT EXISTS `user_work` (
  `userID` int(100) NOT NULL,
  `companyName` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `dateStarted` date NOT NULL,
  `dateEnded` date DEFAULT NULL,
  PRIMARY KEY (`userID`,`companyName`,`position`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `vacancies`
--

CREATE TABLE IF NOT EXISTS `vacancies` (
  `vID` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `deadline` date NOT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `loginRequired` int(11) DEFAULT '0',
  `vCat` varchar(255) NOT NULL,
  `isFilled` varchar(3) DEFAULT 'No',
  PRIMARY KEY (`vID`),
  KEY `vCatID` (`vCat`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=32 ;

--
-- Dumping data for table `vacancies`
--

INSERT INTO `vacancies` (`vID`, `title`, `description`, `deadline`, `dateCreated`, `loginRequired`, `vCat`, `isFilled`) VALUES
(9, 'Post Doc Person', 'Things will need to be done. Post Doc things.', '2017-09-11', '2017-08-12 23:05:33', 1, 'Post Doctoral', 'No'),
(15, 'Worker Dude', 'Work work', '2017-09-27', '2017-08-14 13:01:01', 1, 'General', 'No'),
(16, 'Assistant', 'Assist with things', '0000-00-00', '2017-08-31 12:16:33', 1, 'Research', 'No'),
(20, 'Scientist', 'Make mad science', '2017-09-11', '2017-09-07 14:24:36', 1, 'Post Doctoral', 'No'),
(22, 'Sweeper', 'Sweep the grounds', '2018-03-10', '2017-09-11 19:50:59', 0, 'General', 'No'),
(24, 'Research Assistant', 'Assist with things.', '2017-09-30', '2017-09-11 20:27:13', 1, 'Post Doctoral', 'No'),
(25, 'Research Assistant', 'Assist with things.', '2017-09-30', '2017-09-11 20:27:40', 1, 'PHD', 'Yes'),
(26, 'Research Lab Assistant', 'Assist with things in the lab.', '2017-11-01', '2017-09-11 20:29:21', 1, 'Research', 'No'),
(27, 'Research Supervisor', 'Oversee things in the lab.', '2017-11-01', '2017-09-11 20:30:21', 1, 'Research', 'No'),
(28, 'Project Supervisor', 'Oversee things in the project.', '2017-11-01', '2017-09-11 20:31:18', 0, 'PHD', 'No'),
(29, 'Project Supervisor', 'Oversee things in the project.', '2017-11-01', '2017-09-11 20:32:52', 0, 'Post Doctoral', 'No'),
(30, 'Secretary', 'Help with things', '2017-11-01', '2017-09-11 20:33:23', 0, 'General', 'No'),
(31, 'Project Supervisor', 'Make science', '2017-09-21', '2017-09-14 12:54:14', 0, 'PHD', 'No');

-- --------------------------------------------------------

--
-- Table structure for table `v_applications`
--

CREATE TABLE IF NOT EXISTS `v_applications` (
  `appID` int(11) NOT NULL AUTO_INCREMENT,
  `vID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `CV` varchar(255) NOT NULL,
  `websiteLink` varchar(255) DEFAULT NULL,
  `dateApplied` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`appID`),
  KEY `fk_vIDApps` (`vID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=21 ;

--
-- Dumping data for table `v_applications`
--

INSERT INTO `v_applications` (`appID`, `vID`, `name`, `email`, `contact`, `country`, `CV`, `websiteLink`, `dateApplied`) VALUES
(10, 9, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(12, 16, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(13, 15, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(19, 24, 'John Doe', 'john@doe.com', '123456789', 'Albania', 'http://localhost/infocomm/uploads/John_Doe.pdf', '', '2017-09-28 20:46:19'),
(20, 22, 'Mike Dean', 'a@b.com', '+1234567890', 'Anguilla', 'http://localhost/infocomm/uploads/Mike_Dean.pdf', 'http://cool.com', '2017-10-04 15:22:59');

-- --------------------------------------------------------

--
-- Table structure for table `v_appreferences`
--

CREATE TABLE IF NOT EXISTS `v_appreferences` (
  `vAppID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  KEY `vAppID` (`vAppID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `v_appreferences`
--

INSERT INTO `v_appreferences` (`vAppID`, `name`, `position`, `contact`) VALUES
(12, 'Denny', 'Boss Man', '8888888'),
(19, 'Mr Price', 'Researcher (Infocom labs)', '123456789'),
(20, '', '', '');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `event_media`
--
ALTER TABLE `event_media`
  ADD CONSTRAINT `event_media_ibfk_1` FOREIGN KEY (`eventID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE;

--
-- Constraints for table `follows`
--
ALTER TABLE `follows`
  ADD CONSTRAINT `follows_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `news`
--
ALTER TABLE `news`
  ADD CONSTRAINT `fk_user` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `news_media`
--
ALTER TABLE `news_media`
  ADD CONSTRAINT `news_media_ibfk_1` FOREIGN KEY (`newsID`) REFERENCES `news` (`newsID`);

--
-- Constraints for table `post_comments`
--
ALTER TABLE `post_comments`
  ADD CONSTRAINT `post_comments_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `post_comments_ibfk_2` FOREIGN KEY (`postID`) REFERENCES `project_posts_old` (`postID`);

--
-- Constraints for table `project_collaborators`
--
ALTER TABLE `project_collaborators`
  ADD CONSTRAINT `project_collaborators_ibfk_1` FOREIGN KEY (`collabID`) REFERENCES `collaborators` (`collaboratorID`),
  ADD CONSTRAINT `project_collaborators_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_events`
--
ALTER TABLE `project_events`
  ADD CONSTRAINT `fkprojecteventseid` FOREIGN KEY (`eid`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fkprojecteventspid` FOREIGN KEY (`pid`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_followers`
--
ALTER TABLE `project_followers`
  ADD CONSTRAINT `project_followers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_followers_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_funders`
--
ALTER TABLE `project_funders`
  ADD CONSTRAINT `project_funders_ibfk_2` FOREIGN KEY (`funderName`) REFERENCES `funders` (`FunderName`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_funders_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_members`
--
ALTER TABLE `project_members`
  ADD CONSTRAINT `project_members_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_members_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_posts`
--
ALTER TABLE `project_posts`
  ADD CONSTRAINT `project_posts_ibfk_1` FOREIGN KEY (`pID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE;

--
-- Constraints for table `project_posts_comments`
--
ALTER TABLE `project_posts_comments`
  ADD CONSTRAINT `project_posts_comments_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `project_posts_comments_ibfk_2` FOREIGN KEY (`upID`) REFERENCES `project_posts` (`upID`) ON DELETE CASCADE;

--
-- Constraints for table `project_posts_old`
--
ALTER TABLE `project_posts_old`
  ADD CONSTRAINT `project_posts_old_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_posts_old_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_publications`
--
ALTER TABLE `project_publications`
  ADD CONSTRAINT `project_publications_ibfk_1` FOREIGN KEY (`pubID`) REFERENCES `user_publications` (`pubID`),
  ADD CONSTRAINT `project_publications_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_research`
--
ALTER TABLE `project_research`
  ADD CONSTRAINT `project_research_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `reportedusers`
--
ALTER TABLE `reportedusers`
  ADD CONSTRAINT `reportedusers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `securityquestion`
--
ALTER TABLE `securityquestion`
  ADD CONSTRAINT `securityquestion_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `fk_pos` FOREIGN KEY (`designation`) REFERENCES `positions` (`designation`);

--
-- Constraints for table `user_education`
--
ALTER TABLE `user_education`
  ADD CONSTRAINT `user_education_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_posts`
--
ALTER TABLE `user_posts`
  ADD CONSTRAINT `user_posts_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Constraints for table `user_posts_comments`
--
ALTER TABLE `user_posts_comments`
  ADD CONSTRAINT `user_posts_comments_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE,
  ADD CONSTRAINT `user_posts_comments_ibfk_2` FOREIGN KEY (`upID`) REFERENCES `user_posts` (`upID`) ON DELETE CASCADE;

--
-- Constraints for table `user_projects`
--
ALTER TABLE `user_projects`
  ADD CONSTRAINT `user_projects_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `user_projects_ibfk_2` FOREIGN KEY (`catID`) REFERENCES `categories_project` (`catID`);

--
-- Constraints for table `user_publications`
--
ALTER TABLE `user_publications`
  ADD CONSTRAINT `user_publications_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `user_publications_ibfk_2` FOREIGN KEY (`category`) REFERENCES `categories_project` (`catID`);

--
-- Constraints for table `user_ri`
--
ALTER TABLE `user_ri`
  ADD CONSTRAINT `user_ri_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_timeline`
--
ALTER TABLE `user_timeline`
  ADD CONSTRAINT `user_timeline_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_work`
--
ALTER TABLE `user_work`
  ADD CONSTRAINT `user_work_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `v_applications`
--
ALTER TABLE `v_applications`
  ADD CONSTRAINT `fk_vIDApps` FOREIGN KEY (`vID`) REFERENCES `vacancies` (`vID`) ON DELETE CASCADE;

--
-- Constraints for table `v_appreferences`
--
ALTER TABLE `v_appreferences`
  ADD CONSTRAINT `fk_appRef` FOREIGN KEY (`vAppID`) REFERENCES `v_applications` (`appID`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
