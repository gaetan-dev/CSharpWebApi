use Starter;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `example`; 
SET FOREIGN_KEY_CHECKS = 1;

-- -------------------------------------------------------
-- 						PS_CreateExample
-- -------------------------------------------------------

CALL PS_CreateExample 
(
'1',
'Prop01',
'Prop02')
;

-- -------------------------------------------------------
-- 						PS_PostExample
-- -------------------------------------------------------

CALL PS_CreateExample 
(
'2',
'Prop11',
'Prop12')
;