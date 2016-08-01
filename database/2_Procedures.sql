use Starter;

-- --------------------------------------------------------------------------------
-- 								PS_ReadAllExamples
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_ReadAllExamples`;

DELIMITER |
CREATE PROCEDURE `PS_ReadAllExamples` ()
	SELECT * FROM `Example`;
|
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_ReadExampleById
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_ReadExampleById`;

DELIMITER |
CREATE PROCEDURE `PS_ReadExampleById` (
	in P_Id VARCHAR(50)
)
	SELECT * FROM `Example` WHERE Id = P_Id;
|
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_CreateExample
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_CreateExample`;

DELIMITER |
CREATE PROCEDURE `PS_CreateExample` (
	in P_Id VARCHAR(50),
	in P_Prop1 varchar(50),
	in P_Prop2 varchar(50)
)
BEGIN
	INSERT INTO `Starter`.`Example`( Id, Prop1, Prop2 )
	VALUES ( P_Id, P_Prop1, P_Prop2 );
    
    CALL PS_ReadExampleById(P_Id); 
END |
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_UpdateExample
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_UpdateExample`;

DELIMITER |
CREATE PROCEDURE `PS_UpdateExample` (
	in P_Id VARCHAR(50),
	in P_Prop1 varchar(50),
	in P_Prop2 varchar(50)
)
BEGIN
	UPDATE `Starter`.`Example` SET Prop1 = P_Prop1, Prop2 = P_Prop2
    WHERE Id = P_Id;
    
    CALL PS_ReadExampleById(P_Id); 
END |
DELIMITER ;

-- --------------------------------------------------------------------------------
-- 								PS_DeleteExample
-- --------------------------------------------------------------------------------

Drop procedure if exists `PS_DeleteExample`;

DELIMITER |
CREATE PROCEDURE `PS_DeleteExample` (
	in P_Id VARCHAR(50)
)
	DELETE FROM `Example` WHERE id = P_id; 
|
DELIMITER ;