use Luncher;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `avecquiatonmange`; 
SET FOREIGN_KEY_CHECKS = 1;

CALL Create_AvecQuiATOnMange(1,2);
CALL Create_AvecQuiATOnMange(1,2);
CALL Create_AvecQuiATOnMange(1,3);
CALL Create_AvecQuiATOnMange(1,3);
CALL Create_AvecQuiATOnMange(3,1);
CALL Create_AvecQuiATOnMange(1,6);
CALL Create_AvecQuiATOnMange(6,1);
CALL Create_AvecQuiATOnMange(1,8);
CALL Create_AvecQuiATOnMange(7,8);
CALL Create_AvecQuiATOnMange(5,6);
CALL Create_AvecQuiATOnMange(8,3);
CALL Create_AvecQuiATOnMange(3,4);
