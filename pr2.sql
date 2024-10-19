SELECT * 
FROM pr2.users
ORDER BY LEFT(User_name, 1);

DELIMITER //

DROP PROCEDURE IF EXISTS GetEvenIDs;

CREATE PROCEDURE GetEvenIDs()
BEGIN
    SELECT *
    FROM pr2.users
    WHERE MOD(id, 2) = 0; -- Використовується MOD для визначення парних id
END //

DELIMITER ;

CALL GetEvenIDs();