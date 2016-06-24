use Starter;

-- --------------------------------------------------------------------------------
-- 								PS_GetAllExamples
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_GetAllExamples`;

DELIMITER |
CREATE PROCEDURE `PS_GetAllExamples` ()
	SELECT * FROM `Example`;
|
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_GetExampleById
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_GetExampleById`;

DELIMITER |
CREATE PROCEDURE `PS_GetExampleById` (
	in P_Id INT
)
	SELECT * FROM `Example` WHERE Id = P_Id;
|
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_SetExample
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_SetExample`;

DELIMITER |
CREATE PROCEDURE `PS_SetExample` (
	in P_Id INT,
	in P_Prop1 varchar(50),
	in P_Prop2 varchar(50)
)
	IF (P_Id IS NULL OR P_Id < 1) THEN
		INSERT INTO `Starter`.`Example`( Id, Prop1, Prop2 )
		VALUES ( P_Id, P_Prop1, P_Prop2 );
	ELSE 
		UPDATE `Starter`.`Example` SET Id = P_Id, Prop1 = P_Prop1, Prop2 = P_Prop2;
	END IF
|
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_DeleteExample
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_DeleteExample`;

DELIMITER |
CREATE PROCEDURE `PS_DeleteExample` (
	IN P_Id INT
)
	DELETE FROM `Example` WHERE id = P_id; 
|
DELIMITER ;