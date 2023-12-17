Must do in order for mysql to work : 

AFTER .sql is done, you must manually add : 

"DELIMITER //

CREATE PROCEDURE pets.spPets_GetAllAssigned(
    IN user_id_param INT
)
BEGIN
    -- Add any specific validations or business logic if needed
    
    -- Retrieve pet details based on the owner_id
    SELECT *
    FROM pet_details
    WHERE owner_id = user_id_param;
    
    -- Add additional logic if needed
    
END //

DELIMITER ;
"

[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/C_wGfqQt)
