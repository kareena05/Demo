-- INSERT INTO practice.employee VALUES(null,'neha','1995-01-23',20000), 
-- (null,'Nick','1994-02-26',34000),
-- (null,'Virat','1998-06-03',52000),
-- (null,'jonas','2000-02-23',20000);

-- UPDATE practice.employee SET emp_name="yasin",salary=45000  WHERE emp_id=2;-- 
CALL get_emp_count(32,@result);
SELECT @result AS numberOfRecords;

CALL get_employee(32);


SET @val = 10;
CALL increment(@val);
SELECT @val as valuess;