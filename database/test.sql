use luncher;

call Read_AllClients();

call Read_AllThemes();
call Read_ThemeNoPropose(1);
call create_Theme("La boxe", "Vive la boxe", 1);

call Read_AllGroupes();

call Read_AllLikes();
call Read_Like_By_Id_Client('S622319');
call Read_Like_By_Id_Client(2);


call Read_AllAvecQuiATOnmange();
call Read_AvecQuiATOnMange(1);


call Read_AllGroupCompositions();
call Read_GroupComposition_By_Id_Client(14);
call Read_GroupComposition_By_Id_Group(1);

call Read_AllDisponibles();
call Read_Disponible_By_Id_Client('S622319');
call Read_Disponible_By_Date(date(now()));

SET FOREIGN_KEY_CHECKS = 0; 
TRUNCATE `group`; 
TRUNCATE `groupComposition`; 
SET FOREIGN_KEY_CHECKS = 1;

select date_format(now(), '%d-%m-%Y');

call Read_Disponible_By_Id_Client('S622319');
CALL create_Disponible('S622319', now());
CALL update_Disponible('S622319', now());
CALL read_Disponible('S622319', '2015-03-1 16:19:22');

select * from `like`;