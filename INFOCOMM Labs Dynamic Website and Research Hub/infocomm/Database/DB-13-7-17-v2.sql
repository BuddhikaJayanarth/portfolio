-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2017 at 04:51 PM
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
-- Table structure for table `categories_project`
--

CREATE TABLE IF NOT EXISTS `categories_project` (
  `catID` int(11) NOT NULL AUTO_INCREMENT,
  `catName` varchar(255) NOT NULL,
  PRIMARY KEY (`catID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

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
(22, '');

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
(1, 'Ruissa University', 'Teaching', 'James Nelson Jr', 'wwww.russiauni.com', ''),
(2, 'China University', 'Teaching', 'James', 'www.chinauni.com', '/path/to/logo'),
(3, 'China University', 'Science', 'James', 'www.chinauni.com', '/path/to/logo');

-- --------------------------------------------------------

--
-- Table structure for table `events`
--

CREATE TABLE IF NOT EXISTS `events` (
  `eventID` int(11) NOT NULL AUTO_INCREMENT,
  `eventName` varchar(255) NOT NULL,
  `eventTime` time NOT NULL,
  `duration` int(11) NOT NULL,
  `location` varchar(255) DEFAULT NULL,
  `description` text,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`eventID`),
  KEY `adminID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `event_media`
--

CREATE TABLE IF NOT EXISTS `event_media` (
  `eventID` int(11) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`eventID`,`link`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
  `projectID` int(11) NOT NULL,
  `collabID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`collabID`),
  KEY `collabID` (`collabID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_followers`
--

CREATE TABLE IF NOT EXISTS `project_followers` (
  `projectID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_funders`
--

CREATE TABLE IF NOT EXISTS `project_funders` (
  `projectID` int(11) NOT NULL,
  `funderName` varchar(255) NOT NULL,
  PRIMARY KEY (`projectID`,`funderName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_members`
--

CREATE TABLE IF NOT EXISTS `project_members` (
  `projectID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`userID`),
  KEY `userID` (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_posts`
--

CREATE TABLE IF NOT EXISTS `project_posts` (
  `postID` int(11) NOT NULL AUTO_INCREMENT,
  `projectID` int(11) NOT NULL,
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
  `projectID` int(11) NOT NULL,
  `pubID` int(11) NOT NULL,
  PRIMARY KEY (`projectID`,`pubID`),
  KEY `pubID` (`pubID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `project_research`
--

CREATE TABLE IF NOT EXISTS `project_research` (
  `projectID` int(11) NOT NULL,
  `researchTopic` varchar(255) NOT NULL,
  PRIMARY KEY (`projectID`,`researchTopic`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `userID` int(100) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `title`, `fname`, `lname`, `gender`, `dob`, `email`, `password`, `userType`, `designation`, `lastLogin`, `dateJoined`, `accessLevel`, `status`, `city`, `country`, `facebook`, `googlePlus`, `linkedIn`, `twitter`, `website`, `bio`, `interest`, `phone`, `activationKey`) VALUES
(1, 'Mr.', 'John', 'Doe', 'M', '2017-08-08', 'john@doe.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Engineer', '2017-09-13 16:20:44', '2017-08-01', 1, 'Activated', 'Colombo', 'Sri Lanka', 'facebook.com/john', NULL, NULL, NULL, NULL, '', 'Cats; Ducks; Golf', '', NULL),
(2, 'Ms.', 'Jackie', 'Riener', 'F', '1917-05-01', 'jackieRiener@mail.com', 'ducksrool', 'G', NULL, '2017-05-01 00:00:00', '2017-04-24', 4, 'Pending', 'Duck City', 'Duckland', 'facebook.com/ducky', NULL, NULL, NULL, NULL, 'Some text that describes me lorem ipsum ipsum lorem.', 'Ducks; Cats; Hockey', NULL, NULL),
(3, 'Sir', 'Joe', 'Doe', 'M', '2017-03-14', 'joe_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Researcher', '2017-09-06 00:00:00', '2017-09-06', 2, 'Deactivated', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(4, 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 1, 'Approved', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(5, 'Ms', 'Jane', 'Doe', 'M', '2017-03-14', 'jane_doe@mail.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', 'Head Lab Supervisor', '2017-09-06 00:00:00', '2017-09-06', 3, 'Suspended', 'City', 'Country', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

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
(2, 1, 'Tokyo University', 'Masters in Fine Arts', '0000-00-00', '0000-00-00'),
(3, 1, 'University of Toronto', 'Phd Robotics', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `user_projects`
--

CREATE TABLE IF NOT EXISTS `user_projects` (
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL AUTO_INCREMENT,
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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=17 ;

--
-- Dumping data for table `user_projects`
--

INSERT INTO `user_projects` (`userID`, `projectID`, `catID`, `projectTitle`, `startDate`, `endDate`, `description`, `imageLink`, `dateCreated`) VALUES
(1, 1, 1, 'One More Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, 2, 1, 'Test Project', '2017-08-14', NULL, 'This is a project description', NULL, '2017-08-01'),
(1, 3, 1, 'Another Project', '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, '2017-07-20'),
(1, 8, 6, 'Analysing radio wave density with altitude', '2017-08-14', '0000-00-00', 'Investigating the affects of atmospheric density on radio waves', 'imagelink', '2017-09-13'),
(4, 13, 6, 'Analysing radio wave density with altitude', '2017-08-14', '0000-00-00', 'SGFV', 'imagelink', '2017-09-13');

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
(2, 1, 'Chapter on Engineering', 'Book Chapter', 2, 'www.book.com', 1, '2010-08-15'),
(5, 1, 'Conference on Human Genome', 'Journal', 2, 'www.ieee.org/Jack/ConferenceonHumanGenome', 0, '2017-08-01'),
(6, 1, 'Book on Human Genome', 'Book', 1, 'www.ieee.org/Jack/BookonHumanGenome', 0, '2014-08-01'),
(7, 1, 'Publiction 300', 'Book', 5, 'www.book.com', 0, '2017-09-11');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Dumping data for table `user_timeline`
--

INSERT INTO `user_timeline` (`id`, `userID`, `subject`, `activity`, `body`, `dateTimeline`) VALUES
(1, 1, 'Education', 'You updated your Education Info', 'Changes were made to qualification <strong>BSc Engineering</strong>', '2017-09-12 15:52:38'),
(2, 1, 'Bio', 'You updated your Bio and Interests', '', '2017-09-11 13:26:57');

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
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=31 ;

--
-- Dumping data for table `vacancies`
--

INSERT INTO `vacancies` (`vID`, `title`, `description`, `deadline`, `dateCreated`, `loginRequired`, `vCat`, `isFilled`) VALUES
(9, 'Post Doc Person', 'Things will need to be done. Post Doc things.', '2017-09-11', '2017-08-12 23:05:33', 1, 'Post Doctoral', 'No'),
(15, 'Worker Dude', 'Work work', '2017-09-23', '2017-08-14 13:01:01', 1, 'General', 'No'),
(16, 'Assistant', 'Assist with things', '0000-00-00', '2017-08-31 12:16:33', 1, 'Research', 'No'),
(20, 'Scientist', 'Make mad science', '2017-09-11', '2017-09-07 14:24:36', 1, 'Post Doctoral', 'No'),
(22, 'Sweeper', 'Sweep the grounds', '2018-03-10', '2017-09-11 19:50:59', 0, 'General', 'No'),
(24, 'Research Assistant', 'Assist with things.', '2017-09-30', '2017-09-11 20:27:13', 1, 'Post Doctoral', 'No'),
(25, 'Research Assistant', 'Assist with things.', '2017-09-30', '2017-09-11 20:27:40', 1, 'PHD', 'No'),
(26, 'Research Lab Assistant', 'Assist with things in the lab.', '2017-11-01', '2017-09-11 20:29:21', 1, 'Research', 'No'),
(27, 'Research Supervisor', 'Oversee things in the lab.', '2017-11-01', '2017-09-11 20:30:21', 1, 'Research', 'No'),
(28, 'Project Supervisor', 'Oversee things in the project.', '2017-11-01', '2017-09-11 20:31:18', 0, 'PHD', 'No'),
(29, 'Project Supervisor', 'Oversee things in the project.', '2017-11-01', '2017-09-11 20:32:52', 0, 'Post Doctoral', 'No'),
(30, 'Secretary', 'Help with things', '2017-11-01', '2017-09-11 20:33:23', 0, 'General', 'No');

-- --------------------------------------------------------

--
-- Table structure for table `v_applications`
--

CREATE TABLE IF NOT EXISTS `v_applications` (
  `vID` int(11) NOT NULL,
  `appID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `CV` varchar(255) NOT NULL,
  `websiteLink` varchar(255) DEFAULT NULL,
  `dateApplied` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`appID`),
  KEY `fk_vIDApps` (`vID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=14 ;

--
-- Dumping data for table `v_applications`
--

INSERT INTO `v_applications` (`vID`, `appID`, `name`, `email`, `contact`, `country`, `CV`, `websiteLink`, `dateApplied`) VALUES
(9, 10, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(16, 12, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10'),
(15, 13, 'Person', 'person@mail.com', '55555555', 'Lanka', 'http://localhost/infocomm/resources/CV/CV.pdf', 'www.personshere.com', '2017-08-31 14:32:10');

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
(12, 'Denny', 'Boss Man', '8888888');

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
  ADD CONSTRAINT `project_collaborators_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_collaborators_ibfk_1` FOREIGN KEY (`collabID`) REFERENCES `collaborators` (`collaboratorID`);

--
-- Constraints for table `project_followers`
--
ALTER TABLE `project_followers`
  ADD CONSTRAINT `project_followers_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_followers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `project_funders`
--
ALTER TABLE `project_funders`
  ADD CONSTRAINT `project_funders_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `project_members`
--
ALTER TABLE `project_members`
  ADD CONSTRAINT `project_members_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_members_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `project_posts`
--
ALTER TABLE `project_posts`
  ADD CONSTRAINT `project_posts_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_posts_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `project_publications`
--
ALTER TABLE `project_publications`
  ADD CONSTRAINT `project_publications_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `project_publications_ibfk_1` FOREIGN KEY (`pubID`) REFERENCES `user_publications` (`pubID`);

--
-- Constraints for table `project_research`
--
ALTER TABLE `project_research`
  ADD CONSTRAINT `project_research_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `events` (`eventID`) ON DELETE CASCADE ON UPDATE CASCADE;

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
  ADD CONSTRAINT `user_projects_ibfk_2` FOREIGN KEY (`catID`) REFERENCES `categories_project` (`catID`),
  ADD CONSTRAINT `user_projects_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;

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
