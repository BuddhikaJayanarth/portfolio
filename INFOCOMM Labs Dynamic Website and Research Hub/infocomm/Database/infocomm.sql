-- phpMyAdmin SQL Dump
-- version 4.5.4.1deb2ubuntu2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 30, 2017 at 07:53 AM
-- Server version: 5.7.19-0ubuntu0.16.04.1
-- PHP Version: 7.0.22-0ubuntu0.16.04.1

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
-- Table structure for table `admins`
--

CREATE TABLE `admins` (
  `adminID` int(11) NOT NULL,
  `password` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `accessLevel` int(11) DEFAULT '0',
  `lastLogin` datetime DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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
(1, 'Miscellenous');

-- --------------------------------------------------------

--
-- Table structure for table `collaborators`
--

CREATE TABLE `collaborators` (
  `collaboratorID` int(11) NOT NULL,
  `affiliation` varchar(255) NOT NULL,
  `department` varchar(255) NOT NULL,
  `contact Person` varchar(255) NOT NULL,
  `website` varchar(255) NOT NULL,
  `logo` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `collaborators`
--

INSERT INTO `collaborators` (`collaboratorID`, `affiliation`, `department`, `contact Person`, `website`, `logo`) VALUES
(1, 'Ruissa University', 'Teaching', 'Dude McDude', 'wwww.russiauni.com', '');

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
  `adminID` int(11) NOT NULL
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
-- Table structure for table `news`
--

CREATE TABLE `news` (
  `newsID` int(11) NOT NULL,
  `headline` varchar(255) NOT NULL,
  `subHeadline` varchar(255) DEFAULT NULL,
  `text` text,
  `date` date NOT NULL,
  `adminID` int(11) NOT NULL
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
  `text` text,
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
-- Table structure for table `positions`
--

CREATE TABLE `positions` (
  `designation` varchar(255),
  `shownInOurteam` int(10) DEFAULT '0'
  
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
--
-- Indexes for table `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`designation`);
-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `userID` int(100) NOT NULL,
  `title` varchar(255) NOT NULL,
  `fname` varchar(255) NOT NULL,
  `lname` varchar(255) NOT NULL,
  `gender` char(1) NOT NULL,
  `dob` date NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `userType` char(1) NOT NULL,
  `designation` varchar(255) DEFAULT NULL,
  FOREIGN KEY (designation) REFERENCES positions(designation),
  `lastLogin` datetime DEFAULT NULL,
  `dateJoined` date DEFAULT NULL,
  `accessLevel` int(10) DEFAULT '1',
  `status` char(1) DEFAULT 'P',
  `city` varchar(255) NOT NULL,
  `country` varchar(255) NOT NULL,
  `facebook` varchar(255) DEFAULT NULL,
  `googlePlus` varchar(255) DEFAULT NULL,
  `linkedIn` varchar(255) DEFAULT NULL,
  `twitter` varchar(255) DEFAULT NULL,
  `website` varchar(255) DEFAULT NULL,
  `bio` text,
  `interest` text
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`userID`, `title`, `fname`, `lname`, `gender`, `dob`, `email`, `password`, `userType`, `designation`, `lastLogin`, `dateJoined`, `accessLevel`, `status`, `city`, `country`, `facebook`, `googlePlus`, `linkedIn`, `twitter`, `website`, `bio`, `interest`) VALUES
(1, 'Prof.', 'John', 'Doe', 'M', '2017-08-08', 'john@doe.com', '$2y$12$K6Do1WB7VFOz8F6TKOIIaO7UPyLILri1hdEHX5Dd1yWZNyJjiMb6q', 'I', NULL, '2017-05-01 00:00:00', '2017-08-01', 1, 'P', 'Colombo', 'Sri Lanka', NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 'Ms.', 'Jackie', 'Riener', 'F', '1917-05-01', 'dd@ducks.com', 'ducksrool', 'G', NULL, '2017-05-01 00:00:00', '2017-04-24', 4, 'A', 'Duck City', 'Duckland', 'facebook.com/ducky', NULL, NULL, NULL, NULL, 'Some text that describes me lorem ipsum ipsum lorem.', 'CEO & Founder'),
(3, 'Mr.', 'Jack', 'Ignis', 'M', '1917-05-01', 'ddd@ducks.com', 'ducksrool', 'I', NULL, '2017-05-01 00:00:00', '2017-04-24', 4, 'A', 'Duck City', 'Duckland', 'facebook.com/ducky', NULL, NULL, NULL, NULL, 'Some text that describes me lorem ipsum ipsum lorem.', 'Director'),
(5, 'Ms.', 'DeDe', 'Doodles', 'X', '2017-03-14', 'dddoodles@mails.com', 'DDDudes', 'G', NULL, NULL, NULL, 5, 'A', 'Raincity', 'Rainland', 'DDDudes', NULL, NULL, NULL, NULL, 'I am DeDe. Call me DeDe. Thanks.', 'I am interested in life and the cosmos and other people called DeDe');

-- --------------------------------------------------------

--
-- Table structure for table `user_education`
--

CREATE TABLE `user_education` (
  `userID` int(100) NOT NULL,
  `institute` varchar(255) NOT NULL,
  `qualification` varchar(255) NOT NULL,
  `startDate` date NOT NULL,
  `gradDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_projects`
--

CREATE TABLE `user_projects` (
  `userID` int(11) NOT NULL,
  `projectID` int(11) NOT NULL,
  `catID` int(11) NOT NULL,
  `projectTitle` varchar(255) NOT NULL,
  `privacy` int(11) NOT NULL DEFAULT '0',
  `startDate` date NOT NULL,
  `endDate` date DEFAULT NULL,
  `description` text,
  `researchGate` varchar(255) DEFAULT NULL,
  `imageLink` varchar(255) DEFAULT NULL,
  `approvalStatus` int(11) NOT NULL DEFAULT '1',
  `dateCreated` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_projects`
--

INSERT INTO `user_projects` (`userID`, `projectID`, `catID`, `projectTitle`, `privacy`, `startDate`, `endDate`, `description`, `researchGate`, `imageLink`, `approvalStatus`, `dateCreated`) VALUES
(1, 0, 1, 'One More Project', 0, '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, NULL, 1, '2017-07-20'),
(1, 1, 1, 'Test Project', 0, '2017-08-14', NULL, 'This is a project description', NULL, NULL, 1, '2017-08-01'),
(1, 2, 1, 'Another Project', 0, '2017-08-01', NULL, 'This is more details about this project. (only for test purposes: ikubofabeofbsknbfsopiefnosfnsoafnsoaefibnesafoiasenfoea skfbniofhnao eoauhnafeofa )', NULL, NULL, 1, '2017-07-20');

-- --------------------------------------------------------

--
-- Table structure for table `user_publications`
--

CREATE TABLE `user_publications` (
  `pubID` int(100) NOT NULL,
  `userID` int(100) NOT NULL,
  `title` varchar(255) NOT NULL,
  `type` char(2) NOT NULL,
  `link` text NOT NULL,
  `isPublic` int(1) DEFAULT '0',
  `datePublished` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_publications`
--

INSERT INTO `user_publications` (`pubID`, `userID`, `title`, `type`, `link`, `isPublic`, `datePublished`) VALUES
(2, 1, 'Chapter on Ducks', 'H', 'www.book.com', 1, '2010-08-15'),
(3, 1, 'Conference on Ducks', 'C', 'www.conference.com', 0, '2000-01-01'),
(4, 2, 'El Journal De Journals', 'J', 'wwww.ieee.com/eljournaldejournals', 1, '2017-08-13');

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
  `vCat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `vacancies`
--

INSERT INTO `vacancies` (`vID`, `title`, `description`, `deadline`, `dateCreated`, `loginRequired`, `vCat`) VALUES
(3, 'Research Dude', 'Thing to do', '2017-08-17', '2017-08-12 22:34:25', 0, 'PHD'),
(7, 'Person', 'Things will need to be done. General things.', '0000-00-00', '2017-08-12 23:00:21', NULL, 'General'),
(8, 'PHD Person', 'Things will need to be done. PHD things.', '0000-00-00', '2017-08-12 23:03:33', 0, 'PHD'),
(9, 'Post Doc Person', 'Things will need to be done. Post Doc things.', '0000-00-00', '2017-08-12 23:05:33', 1, 'Post Doctoral'),
(12, 'General Dude', 'Lalalallala', '0000-00-00', '2017-08-12 23:28:03', NULL, 'General'),
(13, 'Research Dude', 'Lalalallala.\r\nMore lalallalala.', '0000-00-00', '2017-08-12 23:28:31', 1, 'Research'),
(14, 'Research Assistant', 'Help with things in the lab. Not burn down stuff.', '0000-00-00', '2017-08-13 13:14:21', 1, 'Post Doctoral'),
(15, 'Worker', 'Work work', '0000-00-00', '2017-08-14 13:01:01', 1, 'General');

-- --------------------------------------------------------

--
-- Table structure for table `v_applications`
--

CREATE TABLE `v_applications` (
  `vID` int(11) NOT NULL,
  `appID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `contact` int(11) NOT NULL,
  `country` varchar(255) NOT NULL,
  `CV` varchar(255) NOT NULL,
  `websiteLink` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `v_appreferences`
--

CREATE TABLE `v_appreferences` (
  `vAppID` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `position` varchar(255) NOT NULL,
  `contact` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`adminID`);

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
  ADD KEY `adminID` (`adminID`);

--
-- Indexes for table `event_media`
--
ALTER TABLE `event_media`
  ADD PRIMARY KEY (`eventID`,`link`);

--
-- Indexes for table `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`newsID`),
  ADD KEY `adminID` (`adminID`);

--
-- Indexes for table `news_media`
--
ALTER TABLE `news_media`
  ADD PRIMARY KEY (`newsID`,`link`);

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
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `user_education`
--
ALTER TABLE `user_education`
  ADD PRIMARY KEY (`userID`,`institute`,`qualification`);

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
  ADD KEY `userID` (`userID`);

--
-- Indexes for table `user_ri`
--
ALTER TABLE `user_ri`
  ADD PRIMARY KEY (`userID`,`RI`);

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
  ADD KEY `vID` (`vID`);

--
-- Indexes for table `v_appreferences`
--
ALTER TABLE `v_appreferences`
  ADD KEY `vAppID` (`vAppID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `adminID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `categories_project`
--
ALTER TABLE `categories_project`
  MODIFY `catID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `collaborators`
--
ALTER TABLE `collaborators`
  MODIFY `collaboratorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
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
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `user_publications`
--
ALTER TABLE `user_publications`
  MODIFY `pubID` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `vacancies`
--
ALTER TABLE `vacancies`
  MODIFY `vID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `v_applications`
--
ALTER TABLE `v_applications`
  MODIFY `appID` int(11) NOT NULL AUTO_INCREMENT;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `events`
--
ALTER TABLE `events`
  ADD CONSTRAINT `events_ibfk_1` FOREIGN KEY (`adminID`) REFERENCES `admins` (`adminID`);

--
-- Constraints for table `event_media`
--
ALTER TABLE `event_media`
  ADD CONSTRAINT `event_media_ibfk_1` FOREIGN KEY (`eventID`) REFERENCES `events` (`eventID`);

--
-- Constraints for table `news`
--
ALTER TABLE `news`
  ADD CONSTRAINT `news_ibfk_1` FOREIGN KEY (`adminID`) REFERENCES `admins` (`adminID`);

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
  ADD CONSTRAINT `project_collaborators_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_followers`
--
ALTER TABLE `project_followers`
  ADD CONSTRAINT `project_followers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_followers_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_funders`
--
ALTER TABLE `project_funders`
  ADD CONSTRAINT `project_funders_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_members`
--
ALTER TABLE `project_members`
  ADD CONSTRAINT `project_members_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_members_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_posts`
--
ALTER TABLE `project_posts`
  ADD CONSTRAINT `project_posts_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`),
  ADD CONSTRAINT `project_posts_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_publications`
--
ALTER TABLE `project_publications`
  ADD CONSTRAINT `project_publications_ibfk_1` FOREIGN KEY (`pubID`) REFERENCES `user_publications` (`pubID`),
  ADD CONSTRAINT `project_publications_ibfk_2` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

--
-- Constraints for table `project_research`
--
ALTER TABLE `project_research`
  ADD CONSTRAINT `project_research_ibfk_1` FOREIGN KEY (`projectID`) REFERENCES `user_projects` (`projectID`);

  
--
-- Constraints for table `user_education`
--
ALTER TABLE `user_education`
  ADD CONSTRAINT `user_education_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_projects`
--
ALTER TABLE `user_projects`
  ADD CONSTRAINT `FK_userCats` FOREIGN KEY (`catID`) REFERENCES `categories_project` (`catID`),
  ADD CONSTRAINT `user_projects_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_publications`
--
ALTER TABLE `user_publications`
  ADD CONSTRAINT `user_publications_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_ri`
--
ALTER TABLE `user_ri`
  ADD CONSTRAINT `user_ri_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `user_work`
--
ALTER TABLE `user_work`
  ADD CONSTRAINT `user_work_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`);

--
-- Constraints for table `v_applications`
--
ALTER TABLE `v_applications`
  ADD CONSTRAINT `v_applications_ibfk_1` FOREIGN KEY (`vID`) REFERENCES `vacancies` (`vID`);

--
-- Constraints for table `v_appreferences`
--
ALTER TABLE `v_appreferences`
  ADD CONSTRAINT `v_appReferences_ibfk_1` FOREIGN KEY (`vAppID`) REFERENCES `v_applications` (`appID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
