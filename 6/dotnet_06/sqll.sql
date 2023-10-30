CREATE TABLE Schools (
    SchoolID INT PRIMARY KEY,
    SchoolName VARCHAR(255) NOT NULL,
    SchoolAddress VARCHAR(255)
);

INSERT INTO Schools (SchoolID, SchoolName, SchoolAddress) VALUES (1, 'School A', 'Addr A');
INSERT INTO Schools (SchoolID, SchoolName, SchoolAddress) VALUES (2, 'School B', 'Addr B');

CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    TeacherName VARCHAR(255) NOT NULL,
    SchoolID INT,
    FOREIGN KEY (SchoolID) REFERENCES Schools(SchoolID)
);

-- 为School A的班级插入老师
INSERT INTO Teachers (TeacherID, TeacherName, SchoolID)
VALUES
    (1, 'Teacher A1', 1),
    (2, 'Teacher A2', 1),
    (3, 'Teacher A3', 1);
-- 为School B的班级插入老师
INSERT INTO Teachers (TeacherID, TeacherName, SchoolID)
VALUES
    (4, 'Teacher B1', 2),
    (5, 'Teacher B2', 2),
    (6, 'Teacher B3', 2);


CREATE TABLE Classes (
    ClassID INT PRIMARY KEY,
    ClassName VARCHAR(255) NOT NULL,
    SchoolID INT,
    TeacherID INT,
    FOREIGN KEY (SchoolID) REFERENCES Schools(SchoolID),
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);
-- 为学校1创建班级
INSERT INTO Classes (ClassID, ClassName, SchoolID, TeacherID)
VALUES
    (1, 'Class 1A', 1, 1),  -- 第一个参数为ClassID，第二个参数为ClassName，第三个参数为SchoolID，第四个参数为TeacherID
    (2, 'Class 2A', 1, 2),
    (3, 'Class 3A', 1, 3);
-- 为学校2创建班级
INSERT INTO Classes (ClassID, ClassName, SchoolID, TeacherID)
VALUES
    (4, 'Class 1B', 2, 4),
    (5, 'Class 2B', 2, 5),
    (6, 'Class 3B', 2, 6);


CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    StudentName VARCHAR(255) NOT NULL,
    ClassID INT,
    FOREIGN KEY (ClassID) REFERENCES Classes(ClassID)
);
INSERT INTO Students (StudentID, StudentName, ClassID)
VALUES
    (1, 'Student 1', 1),
    (2, 'Student 2', 1),
    (3, 'Student 3', 1),
    (4, 'Student 4', 1),
    (5, 'Student 5', 1),
    (6, 'Student 6', 1),
    (7, 'Student 7', 1),
    (8, 'Student 8', 1),
    (9, 'Student 9', 1),
    (10, 'Student 10', 1),
    (11, 'Student 11', 2),
    (12, 'Student 12', 2),
    (13, 'Student 13', 2),
    (14, 'Student 14', 2),
    (15, 'Student 15', 2),
    (16, 'Student 16', 2),
    (17, 'Student 17', 2),
    (18, 'Student 18', 2),
    (19, 'Student 19', 2),
    (20, 'Student 20', 2),
    (21, 'Student 21', 3),
    (22, 'Student 22', 3),
    (23, 'Student 23', 3),
    (24, 'Student 24', 3),
    (25, 'Student 25', 3),
    (26, 'Student 26', 3),
    (27, 'Student 27', 3),
    (28, 'Student 28', 3),
    (29, 'Student 29', 3),
    (30, 'Student 30', 3),
    (31, 'Student 31', 4),
    (32, 'Student 32', 4),
    (33, 'Student 33', 4),
    (34, 'Student 34', 4),
    (35, 'Student 35', 4),
    (36, 'Student 36', 4),
    (37, 'Student 37', 4),
    (38, 'Student 38', 4),
    (39, 'Student 39', 4),
    (40, 'Student 40', 4),
    (41, 'Student 41', 5),
    (42, 'Student 42', 5),
    (43, 'Student 43', 5),
    (44, 'Student 44', 5),
    (45, 'Student 45', 5),
    (46, 'Student 46', 5),
    (47, 'Student 47', 5),
    (48, 'Student 48', 5),
    (49, 'Student 49', 5),
    (50, 'Student 50', 5),
    (51, 'Student 51', 6),
    (52, 'Student 52', 6),
    (53, 'Student 53', 6),
    (54, 'Student 54', 6),
    (55, 'Student 55', 6),
    (56, 'Student 56', 6),
    (57, 'Student 57', 6),
    (58, 'Student 58', 6),
    (59, 'Student 59', 6),
    (60, 'Student 60', 6);

