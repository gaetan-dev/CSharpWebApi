use Luncher;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `client`; 
TRUNCATE `disponible`; 
TRUNCATE `group`; 
TRUNCATE `groupcomposition`; 
TRUNCATE `theme`; 
TRUNCATE `like`; 
TRUNCATE `restaurant`; 
SET FOREIGN_KEY_CHECKS = 1;


-- -------------------------------------------------------
-- 						TEST 1
-- -------------------------------------------------------

CALL Create_Client 
(
'S1',
'Test',
'1',
'1.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 2
-- -------------------------------------------------------

CALL Create_Client 
(
'S2',
'Test',
'2',
'2.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 3
-- -------------------------------------------------------

CALL Create_Client 
(
'S3',
'Test',
'3',
'3.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 4
-- -------------------------------------------------------

CALL Create_Client 
(
'S4',
'Test',
'4',
'4.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 5
-- -------------------------------------------------------

CALL Create_Client 
(
'S5',
'Test',
'5',
'5.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 6
-- -------------------------------------------------------

CALL Create_Client 
(
'S6',
'Test',
'6',
'6.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						TEST 7
-- -------------------------------------------------------

CALL Create_Client 
(
'S7',
'Test',
'7',
'7.test@axa.fr',
'user')
;

-- -------------------------------------------------------
-- 						Football
-- -------------------------------------------------------

CALL Create_Theme 
(
'Football',
'Vive le football',
'S1')
;


-- -------------------------------------------------------
-- 						Basketball
-- -------------------------------------------------------

CALL Create_Theme 
(
'Basketball',
'Vive le basketball',
'S1')
;


-- -------------------------------------------------------
-- 						Natation
-- -------------------------------------------------------

CALL Create_Theme 
(
'Natation',
'Vive la natation',
'S1')
;


-- -------------------------------------------------------
-- 						Films romantiques
-- -------------------------------------------------------

CALL Create_Theme 
(
'Films romantiques',
'Vive les films romantiques',
'S1')
;


-- -------------------------------------------------------
-- 						Musique
-- -------------------------------------------------------

CALL Create_Theme 
(
'Musique',
'Vive la musique',
'S1')
;


-- -------------------------------------------------------
-- 						Technologie
-- -------------------------------------------------------

CALL Create_Theme 
(
'Technologie',
'Vive la technologie',
'S1')
;


-- -------------------------------------------------------
-- 						Lecture
-- -------------------------------------------------------

CALL Create_Theme 
(
'Lecture',
'Vive la lecture',
'S1')
;


-- -------------------------------------------------------
-- 						Jeux vidéo
-- -------------------------------------------------------

CALL Create_Theme 
(
'Jeux vidéo',
'Vive les jeux vidéo',
'S1')
;


call Create_Disponible('S1', '2015-04-23 12:30');
call Create_Disponible('S2', '2015-04-23 12:30');
call Create_Disponible('S3', '2015-04-23 12:30');
call Create_Disponible('S4', '2015-04-23 12:30');
call Create_Disponible('S5', '2015-04-23 12:30');
call Create_Disponible('S6', '2015-04-23 12:30');
call Create_Disponible('S7', '2015-04-23 12:30');


CALL Create_Like ('S1',1, true);
CALL Create_Like ('S1',2, true);
CALL Create_Like ('S1',5, true);
CALL Create_Like ('S1',6, true);
CALL Create_Like ('S1',7, true);
CALL Create_Like ('S1',8, true);
CALL Create_Like ('S2',1, true);
CALL Create_Like ('S2',2, true);
CALL Create_Like ('S2',8, true);
CALL Create_Like ('S3',2, true);
CALL Create_Like ('S3',5, true);
CALL Create_Like ('S3',7, true);
CALL Create_Like ('S3',8, true);
CALL Create_Like ('S4',3, true);
CALL Create_Like ('S5',4, true);
CALL Create_Like ('S6',5, true);
CALL Create_Like ('S6',3, true);
CALL Create_Like ('S6',8, true);
CALL Create_Like ('S6',2, true);
CALL Create_Like ('S7',6, true);


CALL create_Restaurant('Terrasse 1');
CALL create_Restaurant('L\'entre Terrasse');
CALL create_Restaurant('Le Cadran');
CALL create_Restaurant('Terrasse 2');
CALL create_Restaurant('Terrasse 5');
CALL create_Restaurant('Terrasse 6');