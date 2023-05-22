-- DELETE  FROM practice.employee WHERE emp_id=5;
-- SELECT * FROM practice.employee LIMIT 2;
-- SELECT NOW();-- 
-- ALTER  TABLE practice.employee ADD( age INT);

-- UPDATE practice.employee SET age=29 WHERE emp_id=2;
-- UPDATE practice.employee SET age=30 WHERE emp_id=3;
-- UPDATE practice.employee SET age=35 WHERE emp_id=4;

select * from practice.employee;

-- SELECT MAX(salary) as Maximum_salary from practice.employee;
SELECT  MIN(age) as Youngest_employee from practice.employee;


 SELECT  * from practice.employee WHERE age > (SELECT  MIN(age) from practice.employee);



