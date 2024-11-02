import Assignments from "../components/Assignments";

const storedUser = localStorage.getItem('currentUser');
const parsedUser = JSON.parse(storedUser);
const Course = () => {
    return (
        <main>
            <Assignments courseIds={parsedUser?.classIds} />
        </main>
    )
}
export default Course;