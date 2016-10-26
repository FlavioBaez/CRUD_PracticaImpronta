Create database PruebaCRUD
use PruebaCRUD

create table students(
student_id int IDENTITY(1,1) PRIMARY KEY,
student_ctrl_number char(8),
student_name varchar(50),
student_last_name varchar(50),
student_carreer int FOREIGN KEY REFERENCES carreer(carreer_id),
student_registered_date date
)

create table carreer(
carreer_id int IDENTITY(1,1) PRIMARY KEY,
carreer_name varchar(50),
carreer_status bit
)