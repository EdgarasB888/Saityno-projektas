-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 10, 2023 at 04:33 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `WebDb2`
--

-- --------------------------------------------------------

--
-- Table structure for table `Directors`
--

CREATE TABLE `Directors` (
  `Id` int(11) NOT NULL,
  `FullName` longtext NOT NULL,
  `Gender` longtext NOT NULL,
  `Country` longtext NOT NULL,
  `BirthDate` datetime(6) NOT NULL,
  `RegisterDate` datetime(6) NOT NULL,
  `Biography` longtext NOT NULL,
  `SpokenLanguages` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `Phone` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `IsAvailable` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Directors`
--

INSERT INTO `Directors` (`Id`, `FullName`, `Gender`, `Country`, `BirthDate`, `RegisterDate`, `Biography`, `SpokenLanguages`, `Address`, `Phone`, `Email`, `IsAvailable`) VALUES
(1, 'Jane Smith', 'Female', 'Canada', '1995-08-20 00:00:00.000000', '2022-04-15 10:15:00.000000', 'I am a creative person.', 'English, French', '456 Elm Street, Anytown, USA', '+1 (987) 654-3210', 'janesmith@example.com', 1),
(2, 'Robert Johnson', 'Male', 'United Kingdom', '1988-03-10 00:00:00.000000', '2022-05-12 09:45:00.000000', 'Passionate about art and technology.', 'English', '789 Oak Avenue, Another Town, UK', '+44 (20) 1234-5678', 'robert@example.com', 1),
(3, 'Maria Gonzalez', 'Female', 'Spain', '1993-12-05 00:00:00.000000', '2022-06-18 14:20:00.000000', 'Creating the future through innovation.', 'Spanish, English', '567 Pine Road, Somewhere, Spain', '+34 123 456 789', 'maria@example.com', 1),
(4, 'John Rivas', 'Male', 'United States', '1990-01-15 00:00:00.000000', '2022-07-25 11:30:00.000000', 'I create amazing content for the world to enjoy.', 'English, Spanish', '123 Main Street, Anytown, USA', '+1 (123) 456-7890', 'johndoe@example.com', 1),
(5, 'Emily Wilson', 'Female', 'United States', '1998-06-15 00:00:00.000000', '2022-08-30 16:50:00.000000', 'Bringing stories to life.', 'English, Spanish', '234 Birch Avenue, Hometown, USA', '+1 (345) 678-9012', 'emily@example.com', 1),
(6, 'Michael Lee', 'Male', 'Canada', '1982-02-25 00:00:00.000000', '2022-09-05 18:10:00.000000', 'Creating magic through technology.', 'English', '678 Cedar Street, Anytown, Canada', '+1 (234) 567-8901', 'michael@example.com', 1),
(7, 'Sophia Davis', 'Female', 'United Kingdom', '1990-11-08 00:00:00.000000', '2022-10-10 19:30:00.000000', 'Exploring the world of art.', 'English, French', '345 Redwood Drive, Another Town, UK', '+44 (20) 9876-5432', 'sophia@example.com', 1),
(8, 'David Martinez', 'Male', 'Spain', '1989-04-22 00:00:00.000000', '2022-11-15 20:50:00.000000', 'Innovating for a better world.', 'Spanish, English', '456 Oak Road, Somewhere, Spain', '+34 987 654 321', 'david@example.com', 1),
(9, 'Olivia Taylor', 'Female', 'Australia', '1994-07-12 00:00:00.000000', '2022-12-20 22:10:00.000000', 'Creating art that speaks.', 'English', '789 Willow Avenue, Down Under, Australia', '+61 1234 5678', 'olivia@example.com', 1),
(11, 'Sarah Johnson', 'Female', 'Canada', '1992-07-08 00:00:00.000000', '2023-02-15 12:30:00.000000', 'Passionate about photography.', 'English, French', '789 Maple Avenue, Anytown, Canada', '+1 (876) 543-2109', 'sarah@example.com', 1),
(12, 'Daniel Kim', 'Male', 'South Korea', '1987-11-21 00:00:00.000000', '2023-03-22 14:45:00.000000', 'Exploring the world through art.', 'Korean, English', '456 Oak Street, Seoul, South Korea', '+82 10-1234-5678', 'daniel@example.com', 1),
(13, 'Linda Wilson', 'Female', 'United Kingdom', '1996-04-17 00:00:00.000000', '2023-04-25 08:15:00.000000', 'Creating digital masterpieces.', 'English', '123 Elm Road, Another Town, UK', '+44 (20) 9876-5432', 'linda@example.com', 1),
(14, 'Richard Davis', 'Male', 'Canada', '1984-09-09 00:00:00.000000', '2023-05-28 09:20:00.000000', 'Innovating for a sustainable future.', 'English, French', '789 Pine Lane, Anytown, Canada', '+1 (234) 567-8901', 'richard@example.com', 1),
(15, 'Amanda Smith', 'Female', 'Australia', '1997-02-12 00:00:00.000000', '2023-06-30 15:50:00.000000', 'Passionate about design.', 'English', '234 Cedar Avenue, Sydney, Australia', '+61 9876 5432', 'amanda@example.com', 1),
(16, 'Christopher Brown', 'Male', 'United States', '1980-06-26 00:00:00.000000', '2023-07-05 19:10:00.000000', 'Exploring the intersection of art and technology.', 'English, Spanish', '567 Willow Road, Hometown, USA', '+1 (555) 987-6543', 'chris@example.com', 1),
(17, 'Jessica Wilson', 'Female', 'Canada', '1991-03-03 00:00:00.000000', '2023-08-10 22:45:00.000000', 'Creating art with a message.', 'English', '456 Redwood Drive, Anytown, Canada', '+1 (321) 765-4321', 'jessica@example.com', 1),
(18, 'Thomas Martinez', 'Male', 'Spain', '1983-10-14 00:00:00.000000', '2023-09-15 18:30:00.000000', 'Bringing history to life through art.', 'Spanish, English', '789 Oak Lane, Madrid, Spain', '+34 987 654 321', 'thomas@example.com', 1),
(19, 'Megan Johnson', 'Female', 'Australia', '1999-08-04 00:00:00.000000', '2023-10-20 20:20:00.000000', 'Passionate about visual storytelling.', 'English', '234 Maple Road, Melbourne, Australia', '+61 1234 5678', 'megan@example.com', 1),
(20, 'William Wilson', 'Male', 'United States', '1988-12-11 00:00:00.000000', '2023-11-25 11:55:00.000000', 'Creating art that inspires.', 'English, Spanish', '567 Cedar Lane, Hometown, USA', '+1 (789) 123-4567', 'will@example.com', 1),
(21, 'Laura Brown', 'Female', 'United States', '1996-09-14 00:00:00.000000', '2023-12-05 14:30:00.000000', 'Passionate about cinematography.', 'English', '567 Oak Lane, Hometown, USA', '+1 (555) 123-4567', 'laura@example.com', 1),
(22, 'Andrew Wilson', 'Male', 'Australia', '1991-05-18 00:00:00.000000', '2023-12-15 10:25:00.000000', 'Creating visual experiences.', 'English', '234 Pine Road, Sydney, Australia', '+61 9876 5432', 'andrew@example.com', 1),
(23, 'Isabella Martinez', 'Female', 'Spain', '1993-03-07 00:00:00.000000', '2023-12-20 16:50:00.000000', 'Pushing the boundaries of art.', 'Spanish, English', '456 Cedar Avenue, Madrid, Spain', '+34 987 654 321', 'isabella@example.com', 1),
(24, 'Jacob Smith', 'Male', 'Canada', '1985-08-31 00:00:00.000000', '2023-12-25 11:45:00.000000', 'Capturing emotions through photography.', 'English', '789 Elm Street, Anytown, Canada', '+1 (876) 543-2109', 'jacob@example.com', 1),
(25, 'Sophie Johnson', 'Female', 'United Kingdom', '1990-02-25 00:00:00.000000', '2023-12-30 08:15:00.000000', 'Exploring the world through paint.', 'English, French', '123 Redwood Drive, Another Town, UK', '+44 (20) 9876-5432', 'sophie@example.com', 1),
(26, 'Ethan Lee', 'Male', 'South Korea', '1998-07-10 00:00:00.000000', '2024-01-05 19:20:00.000000', 'Blending tradition and modernity in art.', 'Korean, English', '567 Oak Road, Seoul, South Korea', '+82 10-1234-5678', 'ethan@example.com', 1),
(27, 'Natalie Davis', 'Female', 'Canada', '1994-11-28 00:00:00.000000', '2024-01-10 12:10:00.000000', 'Creating art with a social message.', 'English', '456 Pine Lane, Anytown, Canada', '+1 (321) 765-4321', 'natalie@example.com', 1),
(28, 'Matthew Taylor', 'Male', 'Australia', '1987-04-02 00:00:00.000000', '2024-01-15 20:30:00.000000', 'Visual storytelling in the digital age.', 'English', '789 Cedar Lane, Melbourne, Australia', '+61 1234 5678', 'matthew@example.com', 1),
(29, 'Lucy Wilson', 'Female', 'United States', '1992-06-22 00:00:00.000000', '2024-01-20 16:50:00.000000', 'Bringing nature to life through art.', 'English, Spanish', '234 Redwood Road, Hometown, USA', '+1 (789) 123-4567', 'lucy@example.com', 1),
(30, 'Henry Martinez', 'Male', 'Spain', '1995-09-29 00:00:00.000000', '2024-01-25 11:45:00.000000', 'Art as a reflection of society.', 'Spanish, English', '567 Elm Lane, Madrid, Spain', '+34 876 543 210', 'henry@example.com', 1),
(31, 'Sophia Kim', 'Female', 'South Korea', '1999-11-30 00:00:00.000000', '2024-02-01 09:25:00.000000', 'Exploring traditional and contemporary art.', 'Korean, English', '789 Pine Road, Seoul, South Korea', '+82 10-5678-1234', 'sophiakim@example.com', 1),
(32, 'William Anderson', 'Male', 'Canada', '1986-12-21 00:00:00.000000', '2024-02-05 17:30:00.000000', 'Creating immersive art experiences.', 'English', '234 Cedar Avenue, Anytown, Canada', '+1 (555) 987-6543', 'william@example.com', 1),
(33, 'Olivia Brown', 'Female', 'United Kingdom', '1993-08-14 00:00:00.000000', '2024-02-10 13:15:00.000000', 'Art that challenges perceptions.', 'English, French', '456 Elm Street, Another Town, UK', '+44 (20) 9876-5432', 'olivia@example.com', 1),
(34, 'Benjamin Davis', 'Male', 'United States', '1991-05-11 00:00:00.000000', '2024-02-15 08:50:00.000000', 'Expressing emotions through color and form.', 'English', '567 Oak Lane, Hometown, USA', '+1 (321) 765-4321', 'benjamin@example.com', 1),
(35, 'Grace Taylor', 'Female', 'Canada', '1988-02-17 00:00:00.000000', '2024-02-20 14:20:00.000000', 'Art as a vehicle for storytelling.', 'English, French', '678 Pine Road, Anytown, Canada', '+1 (234) 567-8901', 'grace@example.com', 1),
(36, 'James Martinez', 'Male', 'Australia', '1997-09-28 00:00:00.000000', '2024-02-25 16:30:00.000000', 'Digital art in the age of technology.', 'English', '123 Redwood Drive, Sydney, Australia', '+61 1234 5678', 'james@example.com', 1),
(37, 'Chloe Wilson', 'Female', 'Spain', '1990-03-03 00:00:00.000000', '2024-03-01 18:45:00.000000', 'Art that reflects cultural diversity.', 'Spanish, English', '789 Cedar Lane, Madrid, Spain', '+34 987 654 321', 'chloe@example.com', 1),
(38, 'Daniel Johnson', 'Male', 'South Korea', '1985-04-19 00:00:00.000000', '2024-03-05 21:10:00.000000', 'Art as a form of protest and activism.', 'Korean, English', '234 Pine Avenue, Seoul, South Korea', '+82 10-5678-1234', 'danielj@example.com', 1),
(39, 'Emma Smith', 'Female', 'Canada', '1996-07-23 00:00:00.000000', '2024-03-10 10:05:00.000000', 'Blurring the lines between reality and art.', 'English', '567 Elm Road, Anytown, Canada', '+1 (555) 987-6543', 'emma@example.com', 1),
(40, 'Alexander Lee', 'Male', 'United Kingdom', '1989-12-09 00:00:00.000000', '2024-03-15 15:40:00.000000', 'Art that challenges the status quo.', 'English, French', '123 Oak Lane, Another Town, UK', '+44 (20) 9876-5432', 'alexander@example.com', 1),
(41, 'Mia Anderson', 'Female', 'Australia', '1992-10-03 00:00:00.000000', '2024-03-20 11:15:00.000000', 'Art that engages the audience.', 'English', '456 Pine Avenue, Melbourne, Australia', '+61 1234 5678', 'mia@example.com', 1),
(42, 'Liam Davis', 'Male', 'United States', '1987-06-26 00:00:00.000000', '2024-03-25 19:30:00.000000', 'Art as a form of self-expression.', 'English', '789 Elm Road, Hometown, USA', '+1 (321) 765-4321', 'liam@example.com', 1),
(43, 'Ella Wilson', 'Female', 'Canada', '1995-08-14 00:00:00.000000', '2024-04-01 22:05:00.000000', 'Art that celebrates diversity.', 'English', '234 Oak Avenue, Anytown, Canada', '+1 (555) 987-6543', 'ella@example.com', 1),
(44, 'Noah Taylor', 'Male', 'Australia', '1998-11-05 00:00:00.000000', '2024-04-05 14:20:00.000000', 'Art that tells a personal story.', 'English', '567 Cedar Road, Sydney, Australia', '+61 1234 5678', 'noah@example.com', 1),
(45, 'Ava Johnson', 'Female', 'Spain', '1990-07-02 00:00:00.000000', '2024-04-10 10:45:00.000000', 'Art as a medium of communication.', 'Spanish, English', '789 Pine Lane, Madrid, Spain', '+34 987 654 321', 'ava@example.com', 1),
(46, 'Liam Smith', 'Male', 'South Korea', '1986-02-20 00:00:00.000000', '2024-04-15 16:15:00.000000', 'Art that explores the subconscious.', 'Korean, English', '123 Cedar Avenue, Seoul, South Korea', '+82 10-5678-1234', 'liamsmith@example.com', 1),
(47, 'Zoe Martinez', 'Female', 'Canada', '1997-03-18 00:00:00.000000', '2024-04-20 11:40:00.000000', 'Art that challenges traditional norms.', 'English', '456 Elm Lane, Anytown, Canada', '+1 (555) 987-6543', 'zoe@example.com', 1),
(48, 'Lucas Lee', 'Male', 'United Kingdom', '1988-09-07 00:00:00.000000', '2024-04-25 18:05:00.000000', 'Art as a form of meditation.', 'English', '567 Pine Road, Another Town, UK', '+44 (20) 9876-5432', 'lucas@example.com', 1),
(49, 'Avery Davis', 'Female', 'Australia', '1994-04-22 00:00:00.000000', '2024-05-01 20:30:00.000000', 'Art that explores the human condition.', 'English', '789 Oak Avenue, Melbourne, Australia', '+61 1234 5678', 'avery@example.com', 1),
(50, 'Henry Anderson', 'Male', 'United States', '1991-12-15 00:00:00.000000', '2024-05-05 10:55:00.000000', 'Art as a reflection of life experiences.', 'English', '234 Cedar Lane, Hometown, USA', '+1 (321) 765-4321', 'henry@example.com', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Movies`
--

CREATE TABLE `Movies` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Genre` longtext NOT NULL,
  `PlotSummary` longtext NOT NULL,
  `Budget` double NOT NULL,
  `ProductionStatus` longtext NOT NULL,
  `OriginCountry` longtext NOT NULL,
  `MovieStudioId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `Movies`
--

INSERT INTO `Movies` (`Id`, `Name`, `Genre`, `PlotSummary`, `Budget`, `ProductionStatus`, `OriginCountry`, `MovieStudioId`) VALUES
(1, 'Action Pioneers', 'Action', 'A thrilling action-packed adventure.', 50000000, 'Released', 'USA', 1),
(2, 'Drama Dreams', 'Drama', 'A gripping human drama.', 35000000.5, 'In Production', 'USA', 2),
(3, 'Comedy Carnival', 'Comedy', 'A hilarious comedy rollercoaster.', 25000000.75, 'Post-production', 'USA', 3),
(4, 'Sci-Fi Odyssey', 'Science Fiction', 'A journey into the unknown.', 75000000.25, 'Released', 'USA', 4),
(5, 'The Shawshank Redemption', 'Drama', 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.', 25000000, 'Released', 'USA', 1),
(6, 'The Godfather', 'Crime', 'An offer you can\'t refuse.', 6000000.5, 'Released', 'USA', 2),
(7, 'The Dark Knight', 'Action', 'When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.', 185000000.75, 'Released', 'USA', 3),
(8, 'Pulp Fiction', 'Crime', 'The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine.', 8000000.25, 'Released', 'USA', 4),
(9, 'Inception', 'Science Fiction', 'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.', 160000000, 'Released', 'USA', 5),
(10, 'Spirited Away', 'Animation', 'During her family\'s move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.', 15000000, 'Released', 'Japan', 6),
(11, 'Gone in 60 Seconds', 'Action', 'A retired car thief must steal 50 cars in one night to save his brother\'s life from a dangerous crime lord.', 90000000, 'Released', 'United States', 54),
(12, 'Love and Loss', 'Romance', 'A tale of love and heartbreak.', 20000000.5, 'Pre-production', 'USA', 8),
(13, 'Fantasy Adventure', 'Fantasy', 'An epic adventure in a mystical world.', 60000000.75, 'Development', 'USA', 9),
(14, 'Horror Mansion', 'Horror', 'A group of friends trapped in a haunted mansion.', 18000000.25, 'Released', 'USA', 10),
(15, 'The Matrix', 'Science Fiction', 'A computer hacker discovers a dystopian world controlled by machines.', 90000000, 'Released', 'USA', 11),
(16, 'The Princess Bride', 'Adventure', 'A classic tale of love and adventure.', 25000000, 'Released', 'USA', 12),
(17, 'Eternal Sunshine of the Spotless Mind', 'Romance', 'A couple undergoes a procedure to erase the memories of each other.', 30000000.5, 'Released', 'USA', 13),
(18, 'Jurassic Park', 'Adventure', 'A theme park with genetically engineered dinosaurs goes awry.', 70000000.75, 'Released', 'USA', 14),
(19, 'The Lord of the Rings: The Fellowship of the Ring', 'Fantasy', 'A quest to destroy a powerful ring.', 93000000.25, 'Released', 'New Zealand', 15),
(20, 'Forrest Gump', 'Drama', 'The life story of a man with low intelligence.', 55000000, 'Released', 'USA', 16),
(21, 'Mystery Mansion', 'Mystery', 'A detective investigates a series of mysterious murders in an old mansion.', 35000000.5, 'In Production', 'USA', 23),
(22, 'Comedy Chaos', 'Comedy', 'A group of friends gets into comical situations during a road trip.', 28000000.75, 'Post-production', 'USA', 24),
(23, 'Sci-Fi Dystopia', 'Science Fiction', 'In a future world, a lone hero fights against a dystopian regime.', 70000000.25, 'Development', 'USA', 25),
(24, 'Romantic Getaway', 'Romance', 'A couple finds love during a romantic getaway in a picturesque location.', 25000000, 'Released', 'France', 26),
(25, 'Action Heroes', 'Action', 'A team of skilled individuals come together to save the world from a global threat.', 90000000, 'Released', 'USA', 27),
(26, 'The Great Escape', 'War', 'Prisoners of war plan a daring escape from a high-security camp.', 22000000.5, 'Released', 'UK', 28),
(27, 'Historical Epic', 'Historical', 'A grand historical epic featuring wars and political intrigue.', 75000000.5, 'In Production', 'USA', 25),
(28, 'Supernatural Thriller', 'Thriller', 'A supernatural force terrorizes a small town.', 30000000.75, 'Post-production', 'USA', 26),
(29, 'Animated Adventure', 'Animation', 'A group of animated characters embark on an exciting adventure.', 40000000.25, 'Development', 'USA', 27),
(30, 'Zombie Apocalypse', 'Horror', 'Survivors band together to escape a world overrun by zombies.', 25000000, 'Released', 'USA', 28),
(31, 'The Avengers', 'Action', 'Superheroes join forces to save the world from a powerful threat.', 200000000, 'Released', 'USA', 29),
(32, 'The Shining', 'Horror', 'A family experiences terrifying events in a haunted hotel.', 19000000.5, 'Released', 'USA', 30),
(33, 'Blade Runner', 'Science Fiction', 'A blade runner hunts down rogue replicants in a dystopian future.', 45000000.75, 'Released', 'USA', 31),
(34, 'The Sound of Music', 'Musical', 'A young woman becomes a governess for a widowed naval captain.', 82000000.25, 'Released', 'USA', 32),
(35, 'The Revenant', 'Drama', 'A frontiersman on a fur trading expedition fights for survival after being mauled by a bear.', 135000000, 'Released', 'USA', 33),
(36, 'The Green Mile', 'Drama', 'Death row guards discover a supernatural gift in one of the inmates.', 60000000, 'Released', 'USA', 34),
(37, 'Mad Max: Fury Road', 'Action', 'In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler.', 150000000.5, 'Released', 'Australia', 35),
(38, 'The Silence of the Lambs', 'Thriller', 'An FBI agent seeks the help of a brilliant but insane serial killer to catch another.', 19000000.75, 'Released', 'USA', 36),
(39, 'The Big Lebowski', 'Comedy', 'A slacker is mistaken for a millionaire and gets caught up in a kidnapping plot.', 15000000.25, 'Released', 'USA', 37),
(40, 'The Martian', 'Science Fiction', 'An astronaut is stranded on Mars and must find a way to survive.', 108000000, 'Released', 'USA', 38),
(41, 'The Grand Budapest Hotel', 'Comedy', 'A hotel concierge and his protege get involved in a theft and recovery operation.', 25000000.5, 'Released', 'USA', 40),
(42, 'Gladiator', 'Action', 'A former Roman General seeks revenge against the corrupt emperor who murdered his family.', 103000000.75, 'Released', 'USA', 41),
(43, 'The Pianist', 'Drama', 'A Polish Jewish musician struggles to survive the destruction of the Warsaw ghetto during World War II.', 55000000.25, 'Released', 'France', 42),
(44, 'Inglourious Basterds', 'War', 'A group of Jewish U.S. soldiers plan to assassinate Nazi leaders.', 70000000, 'Released', 'USA', 43),
(45, 'The Social Dilemma', 'Documentary', 'A documentary exploring the impact of social media on society.', 5000000, 'Released', 'USA', 44),
(46, 'Toy Story', 'Animation', 'Toys come to life when their owner is not around.', 30000000.5, 'Released', 'USA', 45),
(47, 'The Pursuit of Happyness', 'Drama', 'A struggling salesman becomes a successful stockbroker while experiencing homelessness.', 55000000.75, 'Released', 'USA', 46),
(49, 'The Fast and the Furious', 'Action', 'An undercover cop infiltrates the world of street racing to catch a gang of hijackers led by a charismatic racer.', 38000000, 'Released', 'United States', 54),
(50, 'Cars', 'Animation', 'A race car gets stuck in a small town and learns the true meaning of friendship and community.', 120000000, 'Released', 'United States', 54);

-- --------------------------------------------------------

--
-- Table structure for table `MovieStudios`
--

CREATE TABLE `MovieStudios` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Address` longtext NOT NULL,
  `Phone` longtext NOT NULL,
  `Email` longtext NOT NULL,
  `DirectorId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `MovieStudios`
--

INSERT INTO `MovieStudios` (`Id`, `Name`, `Address`, `Phone`, `Email`, `DirectorId`) VALUES
(1, 'Paramount Pictures', '123 Hollywood Blvd', '+1-123-456-7890', 'paramount@example.com', 1),
(2, 'Warner Bros. Pictures', '456 Burbank Dr', '+1-234-567-8901', 'warnerbros@example.com', 2),
(3, 'Universal Pictures', '789 Universal St', '+1-345-678-9012', 'universal@example.com', 3),
(4, '20th Century Studios', '321 Los Angeles Ave', '+1-456-789-0123', '20thcentury@example.com', 4),
(5, 'Columbia Pictures', '789 Sunset Blvd', '+1-567-890-1234', 'columbia@example.com', 1),
(6, 'Walt Disney Pictures', '123 Magic Way', '+1-678-901-2345', 'disney@example.com', 5),
(7, 'Lionsgate Films', '456 Park Ave', '+1-789-012-3456', 'lionsgate@example.com', 6),
(8, 'Sony Pictures', '567 Sony St', '+1-890-123-4567', 'sony@example.com', 7),
(9, 'Metro-Goldwyn-Mayer', '456 MGM Lane', '+1-987-654-3210', 'mgm@example.com', 8),
(10, 'New Line Cinema', '123 Cinema Ave', '+1-876-543-2109', 'newline@example.com', 9),
(11, 'Miramax Films', '789 Miramax Blvd', '+1-765-432-1098', 'miramax@example.com', 11),
(12, 'A24 Films', '321 A24 Street', '+1-654-321-0987', 'a24@example.com', 12),
(13, 'MGM Studios', '987 Metro Dr', '+1-234-567-8901', 'mgm@example.com', 8),
(14, 'Focus Features', '123 Focus Dr', '+1-789-012-3456', 'focus@example.com', 13),
(15, 'Paramount Vantage', '456 Vantage St', '+1-890-123-4567', 'vantage@example.com', 14),
(16, 'Fox Searchlight Pictures', '789 Searchlight Rd', '+1-234-567-8901', 'searchlight@example.com', 15),
(17, 'Lakeshore Entertainment', '123 Lakeside Dr', '+1-345-678-9012', 'lakeshore@example.com', 16),
(18, 'STX Entertainment', '789 STX Blvd', '+1-678-901-2345', 'stx@example.com', 19),
(23, 'Blumhouse Productions', '789 Horror St', '+1-234-567-8901', 'blumhouse@example.com', 22),
(24, 'Studio Ghibli', '123 Anime Ave', '+1-345-678-9012', 'ghibli@example.com', 23),
(25, 'Amblin Entertainment', '456 Amblin Rd', '+1-456-789-0123', 'amblin@example.com', 24),
(26, 'Legendary Pictures', '321 Legend Dr', '+1-567-890-1234', 'legendary@example.com', 25),
(27, 'Open Road Films', '789 Open Way', '+1-678-901-2345', 'openroad@example.com', 26),
(28, 'FilmDistrict', '123 Film St', '+1-789-012-3456', 'filmdistrict@example.com', 27),
(29, 'Aardman Animations', '456 Animation Ln', '+1-890-123-4567', 'aardman@example.com', 28),
(30, 'STX Films', '789 Movie Blvd', '+1-234-567-8901', 'stxfilms@example.com', 29),
(31, 'Dimension Films', '123 Dimension Rd', '+1-345-678-9012', 'dimension@example.com', 30),
(32, 'Working Title Films', '456 Working Dr', '+1-456-789-0123', 'workingtitle@example.com', 31),
(33, 'Paramount Animation', '789 Animation St', '+1-765-432-1098', 'paramountanimation@example.com', 29),
(34, 'IFC Films', '789 IFC Lane', '+1-876-543-2109', 'ifcfilms@example.com', 37),
(35, 'Neon', '123 Neon Rd', '+1-098-765-4321', 'neon@example.com', 35),
(36, 'Walt Disney Animation Studios', '321 Magic Way', '+1-654-321-0987', 'disneyanimation@example.com', 5),
(37, 'Amazon Studios', '987 Amazon St', '+1-543-210-9876', 'amazonstudios@example.com', 42),
(38, 'StudioCanal', '456 Canal Ave', '+1-321-098-7654', 'studiocanal@example.com', 44),
(39, 'Entertainment One', '789 EOne Lane', '+1-210-987-6543', 'entertainmentone@example.com', 45),
(40, 'The Weinstein Company', '789 Weinstein St', '+1-876-543-2109', 'weinsteincompany@example.com', 48),
(41, 'Orion Pictures', '321 Orion Lane', '+1-765-432-1098', 'orionpictures@example.com', 49),
(42, 'Lone Star Film Group', '123 Lone Star Lane', '+1-987-654-3210', 'lonestar@example.com', 13),
(43, 'Miracle Entertainment', '456 Miracle Dr', '+1-876-543-2109', 'miracle@example.com', 14),
(44, 'Harmony Gold USA', '789 Harmony Gold Blvd', '+1-765-432-1098', 'harmonygolusa@example.com', 15),
(45, 'IFC Midnight', '321 IFC Midnight Rd', '+1-654-321-0987', 'ifcmidnight@example.com', 16),
(46, 'Overture Films', '987 Overture St', '+1-543-210-9876', 'overturefilms@example.com', 17),
(47, 'Orion Classics', '123 Orion Classics Lane', '+1-432-109-8765', 'orionclassics@example.com', 18),
(48, 'Palm Pictures', '456 Palm Dr', '+1-321-098-7654', 'palmpictures@example.com', 19),
(49, 'Regency Enterprises', '789 Regency Blvd', '+1-210-987-6543', 'regency@example.com', 20),
(50, 'Rogue Pictures', '123 Rogue Lane', '+1-098-765-4321', 'roguepictures@example.com', 21),
(51, 'Shout! Studios', '456 Shout St', '+1-987-654-3210', 'shoutstudios@example.com', 22),
(52, 'Vestron Pictures', '789 Vestron Blvd', '+1-876-543-2109', 'vestronpictures@example.com', 23),
(53, 'Bleecker Street', '456 Bleecker St', '+1-321-098-7654', 'bleecker@example.com', 33),
(54, 'Cinema City Studios', '789 Film Road', '555-987-6543', 'contact@cinemacitystudios.com', 20);

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20231008172212_Initial migration', '7.0.11'),
('20231008191751_Initial migration 2', '7.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Directors`
--
ALTER TABLE `Directors`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Movies`
--
ALTER TABLE `Movies`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Movies_MovieStudioId` (`MovieStudioId`);

--
-- Indexes for table `MovieStudios`
--
ALTER TABLE `MovieStudios`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_MovieStudios_DirectorId` (`DirectorId`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Directors`
--
ALTER TABLE `Directors`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `Movies`
--
ALTER TABLE `Movies`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `MovieStudios`
--
ALTER TABLE `MovieStudios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Movies`
--
ALTER TABLE `Movies`
  ADD CONSTRAINT `FK_Movies_MovieStudios_MovieStudioId` FOREIGN KEY (`MovieStudioId`) REFERENCES `MovieStudios` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `MovieStudios`
--
ALTER TABLE `MovieStudios`
  ADD CONSTRAINT `FK_MovieStudios_Directors_DirectorId` FOREIGN KEY (`DirectorId`) REFERENCES `Directors` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
