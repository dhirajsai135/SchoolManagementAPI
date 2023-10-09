
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Dheeraj>
-- Create date: <October 9th, 2023>
-- Description:	<This will give the enrollments based on students>
-- =============================================
CREATE PROCEDURE GetStudentEnrolledCourses

AS
BEGIN
	
	SELECT S.Name as StudentName,C.Name as CourseName,C.Description,CL.Name as ClassName, CL.Section as SectionName,E.Grade as Marks
	FROM Students S
	JOIN Enrollments E ON S.Id = E.StudentId
	JOIN Classes CL ON E.CourseId = CL.Id
	JOIN Courses C ON E.CourseId = C.Id

END
GO

