UPDATE jobs,employee SET jobs.salary = jobs.salary +(jobs.salary*0.20), 
jobs.Max_salary = jobs.Max_salary+2000,
jobs.Min_salary = jobs.Min_salary+2000 , 
employee.commision_act=employee.commision_act + 0.10;
 WHERE employee.job_id ="PU_CLERK" AND jobs.job_id= "PU_CLERK"
 
 
ALTER TABLE employee 
RENAME new_employee

ALTER TABLE location
ADD region_id INT NOT NULL;


ALTER TABLE locatioN
ADD region_id INT FIRST;

ALTER TABLE locations
ADD region_id INT 
AFTER state_province;


-- change datatype of column
ALTER TABLE locations
MODIFY ID FLOAT;

ALTER TABLE locations
DROP city;


-- renaming column name
ALTER TABLE employee
CHANGE region region_name varchar(25);


ALTER TABLE employee 
ADD PRIMARY KEY (location_id);

ALTER TABLE employee 
ADD PRIMARY KEY (location_id,region_id);


ALTER TABLE  employee
DROP PRIMARY KEY;

ALTER TABLE job_history 
ADD CONSTRAINT fk_job_id 
FOREIGN KEY (job_id) 
REFERENCES jobs(job_iD)


ALTER TABLE employee
DROP FOREIGN KEY fk_job_id;


ALTER TABLE job_history
ADD INDEX indx_job_id(job_id);

ALTER TABLE job_history
DROP INDEX indx_job_id;

//* WRITE YOUR QUERY HERE */

-- SELECT CONCAT(first_name," ",last_name) AS fullname, SALARY , 
--     salary*0.15 AS PF  from employees;

-- SELECT SUM(SALARY) AS salary_payable
--      from employees;


-- SELECT MAX(SALARY),MIN(SALARY) from employees;

-- SELECT COUNT(*) AS number_of_employees ,AVG(salary) FROM employees;

-- SELECT COUNT(DISTINCT job_id) FROM employees; 

-- SELECT UPPER(first_name) FROM employees;

-- SELECT SUBSTRING(FIRST_NAME,1,3) FROM employees;


-- SELECT TRIM(first_name) FROM employees;

-- SELECT first_name,last_name, LENGTH(first_name)+LENGTH(last_name) as 'Length of  Names' FROM employees

-- SELECT FIRST_NAME FROM employees WHERE first_name REGEXP '[0-9]';

-- SELECT round(salary/12 , 2) as monthly_salary FROM employees;

-- SELECT FIRST_NAME,SALARY FROM employees WHERE salary NOT BETWEEN 10000 AND 15000;

-- SELECT FIRST_NAME,HIRE_DATE FROM employees WHERE HIRE_DATE LIKE '1987%';

-- SELECT FIRST_NAME,length(first_name) FROM employees WHERE first_name LIKE '______';

-- -- SELECT FIRST_NAME FROM employees WHERE first_name LIKE '__e%';
-- SELECT AVG(SALARY) as average_salary,COUNT(*)  as employees_in_dep_90 from employees WHERE DEPARTMENT_ID  = 90;

-- SELECT JOB_ID As JOB,COUNT(*)  AS no_of_employees FROM employees
--     GROUP BY(JOB_ID);

-- SELECT MIN(SALARY) As "Lowest Salary",MANAGER_ID FROM employees
-- GROUP BY (MANAGER_ID);


-- SELECT SUM(SALARY) As "Total Salary",DEPARTMENT_ID FROM employees
-- GROUP BY (DEPARTMENT_ID);


-- SELECT JOB_ID,AVG(SALARY) As "Average salary" FROM employees
-- WHERE job_id <> 'IT_PROG '
-- GROUP BY job_id;


-- SELECT department_id,AVG(salary),COUNT(*) FROM employees
-- GROUP BY (DEPARTMENT_ID)
-- having COUNT(*) > 10;


-- SELECT first_name,salary FROM employees
-- WHERE salary > (SELECT salary FROM employees WHERE last_name ='bull');


-- SELECT first_name FROM employees
-- WHERE department_id = (SELECT department_id FROM departments WHERE DEPARTMENT_NAME="IT");

-- SELECT first_name FROM employees
-- WHERE manager_id IN
-- (SELECT EMPLOYEE_ID FROM employees WHERE DEPARTMENT_ID IN 
-- (SELECT department_id FROM departments WHERE LOCATION_ID  IN 
-- (SELECT LOCATION_ID  FROM locations WHERE country_id='US')) );
     
     
-- SELECT first_name from employees WHERE salary > (SELECT AVG(salary) from employees);
     
-- SELECT first_name,salary from employees WHERE salary = (SELECT MIN_SALARY from jobs WHERE employees.job_id = jobs.job_id);
     
-- SELECT first_name,salary from employees 
-- WHERE salary > (SELECT AVG(salary) from employees) AND 
-- department_id IN (SELECT DEPARTMENT_ID from departments WHERE DEPARTMENT_NAME LIKE 'IT%');



-- SELECT first_name,salary from employees 
-- WHERE salary > (SELECT salary from employees WHERE last_name='bell');  

-- SELECT first_name,salary from employees 
-- WHERE salary = (SELECT MIN(salary) from employees);  

-- SELECT first_name,salary FROM employees WHERE salary > ALL
-- (SELECT avg(salary) FROM employees GROUP BY department_id);

-- SELECT first_name,salary FROM employees WHERE salary > ALL (SELECT salary from employees WHERE job_id="SH_CLERK")
-- ORDER BY salary;

--SELECT first_name,department_name FROM employees,departments WHERE employees.department_id = departments.department_id ORDER BY department_name;

--SELECT first_name, salary from employees AS e 
-- WHERE salary > (SELECT AVG(salary) FROM employees AS m WHERE m.department_id = e.department_id );

select salary from employees;

select salary from employees
order by salary
limit 3;



joins queries

/* WRITE YOUR QUERY HERE */



-- SELECT location_id as lid,country_id,country_name FROM locations NATURAL JOIN countries;



-- SELECT first_name,department_id,department_name FROM employees JOIN departments USING (department_id);

-- SELECT e.first_name,e.department_id,e.job_id,d.department_id,l.city FROM employees e 
--     JOIN departments d USING (department_id) 
--     JOIN locations l ON d.location_id=l.location_id 
--     WHERE l.city='London';


-- SELECT e.first_name as emp_name , m.first_name AS manger 
-- FROM employees e
-- JOIN employees m 
-- ON e.manager_id = m.employee_id;



-- SELECT first_name, hire_date FROM employees WHERE hire_date > (SELECT hire_date from employees where last_name ='Jones');

-- SELECT d.department_name,COUNT(*) FROM employees e
-- JOIN departments d
-- ON e.department_id = d.department_id
-- GROUP BY d.department_name
-- ORDER BY d.department_name;


-- SELECT j.job_title,j.job_id,h.end_date-h.start_date FROM jobs j 
-- JOIN job_history h
-- ON j.job_id = h.job_id
-- WHERE h.department_id=90;

-- departments and their managers
-- SELECT d.department_id,m.first_name AS Manager
-- FROM departments d
-- JOIN employees m
-- ON d.manager_id = m.employee_id;


-- SELECT d.department_id,m.first_name AS Manager,l.city
-- FROM departments d
-- JOIN employees m
-- ON d.manager_id = m.employee_id
-- JOIN locations l
-- ON d.location_id=l.location_id

-- SELECT AVG(salary) ,j.job_title FROM employees e
-- JOIN jobs j
-- USING (job_id)
-- GROUP BY j.job_id
-- ORDER  BY job_title;


-- SELECT TRIM(e.first_name),j.job_title, e.salary-j.MIN_SALARY As difference FROM
-- employees e
-- NATURAL JOIN jobs j;



-- SELECT j.* FROM job_history j
-- JOIN employees e
-- ON j.employee_id = e.employee_id
-- WHERE e.salary > 10000;


-- SELECT m.first_name as Manager , m.hire_date AS manager ,DATEDIFF(NOW(),HIRE_DATE)/365 AS experience
-- FROM departments d
-- JOIN employees m 
-- ON d.manager_id = m.employee_id
-- WHERE DATEDIFF(NOW(),HIRE_DATE)/365>15;

