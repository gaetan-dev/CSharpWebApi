use Luncher;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `like`; 
SET FOREIGN_KEY_CHECKS = 1;

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
CALL Create_Like ('S8',7, true);
CALL Create_Like ('S8',1, true);
CALL Create_Like ('S9',8, true);