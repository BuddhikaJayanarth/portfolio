-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 28, 2017 at 07:14 PM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `infocomm`
--

-- --------------------------------------------------------

--
-- Table structure for table `about`
--

CREATE TABLE `about` (
  `ID` int(11) NOT NULL,
  `col1` text NOT NULL,
  `col2` text NOT NULL,
  `col3` text NOT NULL,
  `img1` varchar(255) NOT NULL,
  `img2` varchar(255) NOT NULL,
  `img3` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `about`
--

INSERT INTO `about` (`ID`, `col1`, `col2`, `col3`, `img1`, `img2`, `img3`) VALUES
(1, 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT THIS IS A BUNCH OF CONTENT ', 'http://localhost/infocomm/resources/about/img1.jpg', 'http://localhost/infocomm/resources/about/img2.jpg', 'http://localhost/infocomm/resources/about/img3.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `categories_project`
--

CREATE TABLE `categories_project` (
  `catID` int(11) NOT NULL,
  `catName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(24, 'uncategorized');

-- --------------------------------------------------------

--
-- Table structure for table `collaborators`
--

CREATE TABLE `collaborators` (
  `collaboratorID` int(11) NOT NULL,
  `affiliation` varchar(255) NOT NULL,
  `department` varchar(255) NOT NULL,
  `contactPerson` varchar(255) NOT NULL,
  `website` varchar(255) NOT NULL,
  `logo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `collaborators`
--

INSERT INTO `collaborators` (`collaboratorID`, `affiliation`, `department`, `contactPerson`, `website`, `logo`) VALUES
(1, 'Ruissa University', 'Teaching', 'James Nelson Jr Jr', 'wwww.russiauni.com', ''),
(3, 'China University', 'Science', 'James', 'www.chinauni.com', '/path/to/logo');

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

CREATE TABLE `events` (
  `eventID` int(11) NOT NULL,
  `eventName` varchar(255) NOT NULL,
  `eventTime` time NOT NULL,
  `duration` int(11) NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `description` text,
  `userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `event_media`
--

CREATE TABLE `event_media` (
  `eventID` int(11) NOT NULL,
  `link` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `follows`
--

CREATE TABLE `follows` (
  `userID` int(100) NOT NULL,
  `following` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `follows`
--

INSERT INTO `follows` (`userID`, `following`) VALUES
(1, 4),
(1, 2);

-- --------------------------------------------------------

--
-- Table structure for table `news`
--

CREATE TABLE `news` (
  `newsID` int(11) NOT NULL,
  `headline` varchar(255) NOT NULL,
  `subHeadline` varchar(255) DEFAULT NULL,
  `text` text,
  `date` date NOT NULL,
  `userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `news_media`
--

CREATE TABLE `news_media` (
  `newsID` int(11) NOT NULL,
  `link` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `positions`
--

CREATE TABLE `positions` (
  `designation` varchar(255) NOT NULL DEFAULT '',
  `shownInOurteam` int(10) DEFAULT '-1'
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

CREATE TABLE `post_comments` (
  `commentID` int(11) NOT NULL,
  `postID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `text` text,
  `dateTime` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_collaborators`
--

CREATE TABLE `project_collaborators` (
  `projectID` int(11) NOT NULL,
  `collabID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_followers`
--

CREATE TABLE `project_followers` (
  `projectID` int(11) NOT NULL,
  `userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_funders`
--

CREATE TABLE `project_funders` (
  `projectID` int(11) NOT NULL,
  `funderName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_members`
--

CREATE TABLE `project_members` (
  `projectID` int(11) NOT NULL,
  `userID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_posts`
--

CREATE TABLE `project_posts` (
  `postID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `description` text,
  `mediaLink` varchar(255) DEFAULT NULL,
  `type` char(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_publications`
--

CREATE TABLE `project_publications` (
  `projectID` int(11) NOT NULL,
  `pubID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_research`
--

CREATE TABLE `project_research` (
  `projectID` int(11) NOT NULL,
  `researchTopic` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `reportedusers`
--

CREATE TABLE `reportedusers` (
  `RID` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `reason` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userID` int(100) NOT NULL,
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
  `activationKey` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `username`, `title`, `fname`, `lname`, `gender`, `dob`, `email`, `password`, `userType`, `designation`, `lastLogin`, `dateJoined`, `accessLevel`, `status`, `city`, `country`, `facebook`, `googlePlus`, `linkedIn`, `twitter`, `website`, `bio`, `interest`, `phone`, `activationKey`) VALUES
(1, 'johnDoe', 'Mr.', 'John', 'Doe', 'M', '2017-08-08', 'john@doe.com', '$2y$12$7l.5wvT.Qdw7680tsN/ryOVnG2XZtRh6jJ97BG5BrsKRFLzDqd1Yq', 'I', 'Engineer', '2017-09-28 17:06:43', '2017-08-01', 1, 'Activated', 'Colombo', 'Sri Lanka', 'facebook.com/john', 'google.com', NULL, NULL, NULL, '', 'Cats; Ducks; Golf', '', NULL),
(2, 'jackieRiener', 'Ms.', 'Jackie', 'Riener', 'F', '1917-05-01', 'jackieRiener@mail.com', 'ducksrool', 'G', NULL, '2017-05-01 00:00:00', '2017-04-24', 4, 'Pending', 'Duck City', 'Duckland', 'facebook.com/ducky', NULL, NULL, NULL, NULL, 'Some text that describes me lorem ipsum ipsum lorem.', 'Ducks; Cats; Hockey', NULL, NULL),
(3, 'JoeDoe', 'Sir', 'Joe', 'Doe', 'M', '2017-03-14', 'joe_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Researcher', '2017-09-06 00:00:00', '2017-09-06', 2, 'Deactivated', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'JaneDoe', 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 1, 'Approved', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'JaneDoe22', 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Head Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 3, 'Suspended', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user_education`
--

CREATE TABLE `user_education` (
  `id` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `institute` varchar(255) NOT NULL,
  `qualification` varchar(255) NOT NULL,
  `startDate` date NOT NULL,
  `gradDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_education`
--

INSERT INTO `user_education` (`id`, `userID`, `institute`, `qualification`, `startDate`, `gradDate`) VALUES
(1, 1, 'Curtin University', 'BSc Engineering', '0000-00-00', '0000-00-00'),
(2, 1, 'Tokyo University', 'Masters in Fine Arts', '0000-00-00', '0000-00-00'),
(3, 1, 'University of Toronto', 'Phd Robotics', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `user_projects`
--

CREATE TABLE `user_projects` (
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `catID` int(11) NOT NULL,
  `projectTitle` varchar(255) NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date DEFAULT NULL,
  `description` text,
  `imageLink` varchar(255) DEFAULT NULL,
  `dateCreated` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_projects`
--

INSERT INTO `user_projects` (`userID`, `projectID`, `catID`, `projectTitle`, `startDate`, `endDate`, `description`, `imageLink`, `dateCreated`) VALUES
(1, 1, 1, 'One More Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, 2, 1, 'Test Project', '2017-08-14', NULL, 'This is a project description', NULL, '2017-08-01'),
(1, 3, 1, 'Another Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, 8, 1, 'Analysing radio wave density with altitude', '2017-08-14', '0000-00-00', 'Investigating the affects of atmospheric density on radio waves', 'imagelink', '2017-09-13'),
(1, 9, 2, 'testing', '2017-08-21', '0000-00-00', 'gfdsa', 'imagelink', '2017-09-14');

-- --------------------------------------------------------

--
-- Table structure for table `user_publications`
--

CREATE TABLE `user_publications` (
  `pubID` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `pubTitle` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL,
  `category` int(11) DEFAULT NULL,
  `link` text NOT NULL,
  `isPublic` int(1) DEFAULT '0',
  `datePublished` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_publications`
--

INSERT INTO `user_publications` (`pubID`, `userID`, `pubTitle`, `type`, `category`, `link`, `isPublic`, `datePublished`) VALUES
(2, 1, 'Chapter on Engineering', 'Book Chapter', 2, 'www.book.com', 1, '2010-08-15'),
(5, 1, 'Conference on Human Genome', 'Journal', 2, 'www.ieee.org/Jack/ConferenceonHumanGenome', 0, '2017-08-01'),
(6, 1, 'Book on Human Genome', 'Book', 1, 'www.ieee.org/Jack/BookonHumanGenome', 0, '2014-08-01'),
(7, 1, 'Publiction 300', 'Book', 5, 'www.book.com', 0, '2017-09-11');

-- --------------------------------------------------------

--
-- Table structure for table `user_ri`
--

CREATE TABLE `user_ri` (
  `userID` int(100) NOT NULL,
  `RI` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_timeline`
--

CREATE TABLE `user_timeline` (
  `id` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `subject` varchar(255) NOT NULL,
  `activity` varchar(255) NOT NULL,
  `body` varchar(255) DEFAULT NULL,
  `dateTimeline` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_timeline`
--

INSERT INTO `user_timeline` (`id`, `userID`, `subject`, `activity`, `body`, `dateTimeline`) VALUES
(1, 1, 'Education', 'You updated your Education Info', 'Changes were made to qualification <strong>BSc Engineering</strong>', '2017-09-12 15:52:38'),
(2, 1, 'Bio', 'You updated your Bio and Interests', '', '2017-09-11 13:26:57'),
(3, 1, 'password', 'You changed your password', '', '2017-09-14 09:31:02');

-- --------------------------------------------------------

--
-- Table structure for table `user_work`
--

CREATE TABLE `user_work` (
  `userID` int(100) NOT NULL,
  `companyName` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `dateStarted` date NOT NULL,
  `dateEnded` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `vacancies`
--

CREATE TABLE `vacancies` (
  `vID` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `deadline` date NOT NULL,
  `dateCreated` datetime DEFAULT CURRENT_TIMESTAMP,
  `loginRequired` int(11) DEFAULT '0',
  `vCat` varchar(255) NOT NULL,
  `isFilled` varchar(3) DEFAULT 'No'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vacancies`
--

INSERT INTO `vacancies` (`vID`, `title`, `description`, `deadline`, `dateCreated`, `loginRequired`, `vCat`, `isFilled`) VALUES
(9, 'Post Doc Person', 'Things will need to be done. Post Doc things.', '2017-09-11', '2017-08-12 23:05:33', 1, 'Post Doctoral', 'No'),
(15, 'Worker Dude', 'Work work', '2017-09-27', '2017-08-14 13:01:01', 1, 'General', 'Yes'),
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
(31, 'Science Dude', 'Make science', '2017-09-21', '2017-09-14 12:54:14', 0, 'PHD', 'No');

-- --------------------------------------------------------

--
-- Table structure for table `v_applications`
--

CREATE TABLE `v_applications` (
  `appID` int(11) NOT NULL,
  `vID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `CV` varchar(255) NOT NULL,
  `websiteLink` varchar(255) DEFAULT NULL,
  `dateApplied` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `v_applications`
--

INSERT INTO `v_applications` (`appID`, `vID`, `name`, `email`, `contact`, `country`, `CV`, `websiteLink`, `dateApplied`) VALUES
(10, 9, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(12, 16, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(13, 15, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10');

-- --------------------------------------------------------

--
-- Table structure for table `v_appreferences`
--

CREATE TABLE `v_appreferences` (
  `vAppID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `v_appreferences`
--

INSERT INTO `v_appreferences` (`vAppID`, `name`, `position`, `contact`) VALUES
(12, 'Denny', 'Boss Man', '8888888');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `about`
--
ALTER TABLE `about`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `categories_project`
--
ALTER TABLE `categories_project`
  ADD PRIMARY KEY (`catID`);

--
-- Indexes for table `collaborators`
--
ALTER TABLE `collaborators`
  ADD PRIMARY KEY (`collaboratorID`);

--
-- Indexes for table `events`
--
ALTER TABLE `events`
  ADD PRIMARY KEY (`eventID`),
  ADD KEY `adminID` (`userID`);

--
-- Indexes for table `event_media`
--
ALTER TABLE `event_media`
  ADD PRIMARY KEY (`eventID`,`link`);

--
-- Indexes for table `follows`
--
ALTER TABLE `follows`
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`newsID`),
  ADD KEY `adminID` (`userID`);

--
-- Indexes for table `news_media`
--
ALTER TABLE `news_media`
  ADD PRIMARY KEY (`newsID`,`link`);

--
-- Indexes for table `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`designation`);

--
-- Indexes for table `post_comments`
--
ALTER TABLE `post_comments`
  ADD PRIMARY KEY (`commentID`),
  ADD KEY `userID` (`userID`),
  ADD KEY `postID` (`postID`);

--
-- Indexes for table `project_collaborators`
--
ALTER TABLE `project_collaborators`
  ADD PRIMARY KEY (`projectID`,`collabID`),
  ADD KEY `collabID` (`collabID`);

--
-- Indexes for table `project_followers`
--
ALTER TABLE `project_followers`
  ADD PRIMARY KEY (`projectID`,`userID`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `project_funders`
--
ALTER TABLE `project_funders`
  ADD PRIMARY KEY (`projectID`,`funderName`);

--
-- Indexes for table `project_members`
--
ALTER TABLE `project_members`
  ADD PRIMARY KEY (`projectID`,`userID`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `project_posts`
--
ALTER TABLE `project_posts`
  ADD PRIMARY KEY (`postID`),
  ADD KEY `userID` (`userID`),
  ADD KEY `projectID` (`projectID`);

--
-- Indexes for table `project_publications`
--
ALTER TABLE `project_publications`
  ADD PRIMARY KEY (`projectID`,`pubID`),
  ADD KEY `pubID` (`pubID`);

--
-- Indexes for table `project_research`
--
ALTER TABLE `project_research`
  ADD PRIMARY KEY (`projectID`,`researchTopic`);

--
-- Indexes for table `reportedusers`
--
ALTER TABLE `reportedusers`
  ADD PRIMARY KEY (`RID`,`userID`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`),
  ADD KEY `fk_pos` (`designation`);

--
-- Indexes for table `user_education`
--
ALTER TABLE `user_education`
  ADD PRIMARY KEY (`id`,`userID`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `user_projects`
--
ALTER TABLE `user_projects`
  ADD PRIMARY KEY (`projectID`),
  ADD KEY `userID` (`userID`),
  ADD KEY `FK_userCats` (`catID`);

--
-- Indexes for table `user_publications`
--
ALTER TABLE `user_publications`
  ADD PRIMARY KEY (`pubID`),
  ADD KEY `userID` (`userID`),
  ADD KEY `fk_pubCats` (`category`);

--
-- Indexes for table `user_ri`
--
ALTER TABLE `user_ri`
  ADD PRIMARY KEY (`userID`,`RI`);

--
-- Indexes for table `user_timeline`
--
ALTER TABLE `user_timeline`
  ADD PRIMARY KEY (`id`,`userID`),
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `user_work`
--
ALTER TABLE `user_work`
  ADD PRIMARY KEY (`userID`,`companyName`,`position`);

--
-- Indexes for table `vacancies`
--
ALTER TABLE `vacancies`
  ADD PRIMARY KEY (`vID`),
  ADD KEY `vCatID` (`vCat`);

--
-- Indexes for table `v_applications`
--
ALTER TABLE `v_applications`
  ADD PRIMARY KEY (`appID`),
  ADD KEY `fk_vIDApps` (`vID`);

--
-- Indexes for table `v_appreferences`
--
ALTER TABLE `v_appreferences`
  ADD KEY `vAppID` (`vAppID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `about`
--
ALTER TABLE `about`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `categories_project`
--
ALTER TABLE `categories_project`
  MODIFY `catID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
--
-- AUTO_INCREMENT for table `collaborators`
--
ALTER TABLE `collaborators`
  MODIFY `collaboratorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `events`
--
ALTER TABLE `events`
  MODIFY `eventID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `news`
--
ALTER TABLE `news`
  MODIFY `newsID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `post_comments`
--
ALTER TABLE `post_comments`
  MODIFY `commentID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `project_posts`
--
ALTER TABLE `project_posts`
  MODIFY `postID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `reportedusers`
--
ALTER TABLE `reportedusers`
  MODIFY `RID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `user_education`
--
ALTER TABLE `user_education`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `user_projects`
--
ALTER TABLE `user_projects`
  MODIFY `projectID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT for table `user_publications`
--
ALTER TABLE `user_publications`
  MODIFY `pubID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `user_timeline`
--
ALTER TABLE `user_timeline`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `vacancies`
--
ALTER TABLE `vacancies`
  MODIFY `vID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;
--
-- AUTO_INCREMENT for table `v_applications`
--
ALTER TABLE `v_applications`
  MODIFY `appID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `events`
--
ALTER TABLE `events`
  ADD CONSTRAINT `fk_userEvents` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `event_media`
--
ALTER TABLE `event_media`
  ADD CONSTRAINT `event_media_ibfk_1` FOREIGN KEY (`eventID`) REFERENCES `events` (`eventID`);

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
  ADD CONSTRAINT `post_comments_ibfk_2` FOREIGN KEY (`postID`) REFERENCES `project_posts` (`postID`);

--
-- Constraints for table `project_collaborators`
--
ALTER TABLE `project_collaborators`
  ADD CONSTRAINT `project_collaborators_ibfk_1` FOREIGN KEY (`collabID`) REFERENCES `collaborators` (`collaboratorID`),
  ADD CONSTRAINT `project_collaborators_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

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
  ADD CONSTRAINT `project_posts_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_posts_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_publications`
--
ALTER TABLE `project_publications`
  ADD CONSTRAINT `project_publications_ibfk_1` FOREIGN KEY (`pubID`) REFERENCES `user_publications` (`pubID`),
  ADD CONSTRAINT `project_publications_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_research`
--
ALTER TABLE `project_research`
  ADD CONSTRAINT `project_research_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `reportedusers`
--
ALTER TABLE `reportedusers`
  ADD CONSTRAINT `reportedusers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

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
