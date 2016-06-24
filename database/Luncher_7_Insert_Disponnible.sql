use Luncher;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `Disponible`; 
SET FOREIGN_KEY_CHECKS = 1;

call Create_Disponible('S5', '2015-04-23 12:30');
call Create_Disponible('S6', '2015-04-23 12:30');
call Create_Disponible('S7', '2015-04-23 12:30');
call Create_Disponible('S1', '2015-04-23 12:30');
call Create_Disponible('S2', '2015-04-23 12:30');
call Create_Disponible('S3', '2015-04-23 12:30');
call Create_Disponible('S4', '2015-04-23 12:30');

