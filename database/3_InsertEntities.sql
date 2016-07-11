use Starter;

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `example`; 
SET FOREIGN_KEY_CHECKS = 1;

-- -------------------------------------------------------
-- 						PS_SetExample
-- -------------------------------------------------------

CALL PS_SetExample 
(
null,
'Prop01',
'Prop02')
;

-- -------------------------------------------------------
-- 						PS_SetExample
-- -------------------------------------------------------

CALL PS_SetExample 
(
null,
'Prop11',
'Prop12')
;