-- public."groups" definition

-- Drop table

-- DROP TABLE public."groups";

CREATE TABLE "groups" (
	id int4 NOT NULL,
	group_name varchar(100) NOT NULL,
	CONSTRAINT groups_pkey PRIMARY KEY (id)
);


-- public.students definition

-- Drop table

-- DROP TABLE public.students;

CREATE TABLE students (
	id int4 NOT NULL,
	full_name varchar(200) NOT NULL,
	group_id int4 NOT NULL,
	CONSTRAINT students_pkey PRIMARY KEY (id),
	CONSTRAINT fk_students_groups FOREIGN KEY (group_id) REFERENCES "groups"(id)
);


-- public.grades definition

-- Drop table

-- DROP TABLE public.grades;

CREATE TABLE grades (
	id int4 NOT NULL,
	subject_name varchar(100) NOT NULL,
	score int4 NOT NULL,
	student_id int4 NOT NULL,
	CONSTRAINT grades_pkey PRIMARY KEY (id),
	CONSTRAINT fk_grades_students FOREIGN KEY (student_id) REFERENCES students(id)
);