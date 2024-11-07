import { useContext, useState } from "react";
import { useGetGrades } from "../greatergradesapi/Grades";
import { UserContext } from "../functions/UserContext";
import { deleteAssignment } from "../greatergradesapi/Assignment";
import UpdateAssignmentPopup from "./UpdateAssignmentPopup";

const AssignmentTile = ({ assignment }) => {

    const { currentUser, authToken } = useContext(UserContext);
    const [popupOpen, setPopupOpen] = useState(false);

    const grades = useGetGrades();
    const grade = grades?.filter(grade => grade.assignmentId === assignment.assignmentId);

    const handleRemoveClick = (id) => {
        deleteAssignment(id, authToken)
    }

    const handleUpdateClick = () => {
        setPopupOpen(true);
    }

    return (
        <div className="user-tile">
            <h4 className="user-name">{assignment.name}</h4>
            <p className="user-role">{grade[0]?.score}/{assignment.maxScore}</p>
            {currentUser?.role !== 0 ?
                <div>
                    <div>
                        <button onClick={() => handleRemoveClick(assignment.assignmentId)}>Remove</button>
                        <button onClick={() => handleUpdateClick()}>Update</button>
                    </div>
                    {popupOpen && (
                        <UpdateAssignmentPopup 
                        onClose={() => setPopupOpen(false)}
                        id={assignment.assignmentId}
                        classId={assignment.classId}
                        />
                    )}
                </div>
            :
                <div />
            }
            
        </div>
    )
}
export default AssignmentTile;