USE practice;
DELIMITER //
CREATE trigger upper_fname
BEFORE INSERT 
ON practice.employee
FOR EACH ROW
BEGIN
SET NEW.emp_name = upper(NEW.emp_name);
END//

DELIMITER //
CREATE trigger validate_age
BEFORE INSERT 
ON practice.employee
FOR EACH ROW
BEGIN
IF NEW.age <10 THEN 
SET NEW.emp_age = 18;
END IF;
END//


DROP TRIGGER  practice.validate_age;


DELIMITER //
CREATE trigger validate_age
BEFORE INSERT 
ON practice.employee
FOR EACH ROW
BEGIN
IF NEW.age <10 THEN 
SET NEW.age = 18;
END IF;
END//

DELIMITER //
CREATE trigger name_upper_update
BEFORE UPDATE
ON practice.employee
FOR EACH ROW
BEGIN
IF NEW.age <10 THEN 
SET NEW.emp_name = upper(NEW.emp_name);
END IF;
END//


INSERT INTO employee VALUES(NULL,"rohan","2000-09-30",44000,23);
INSERT INTO employee VALUES(NULL,"Sofiya","2001-05-26",26000,-2);
DELETE FROM employee WHERE emp_name ="rohan";



SELECT emp_name,experience_function(birth_date) AS experience FROM employee;

call get_employee(29);