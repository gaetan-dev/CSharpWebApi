use Luncher;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `restaurant`; 
SET FOREIGN_KEY_CHECKS = 1;

CALL create_Restaurant('Terrasse 1');
CALL create_Restaurant('L\'entre Terrasse');
CALL create_Restaurant('Le Cadran');
CALL create_Restaurant('Terrasse 2');
CALL create_Restaurant('Terrasse 5');
CALL create_Restaurant('Terrasse 6');