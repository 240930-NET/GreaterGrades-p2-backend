import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import Tiles from "./Tiles";


const DashboardContent = () => {
    const { currentUser } = useContext(UserContext);

    // if user is student display this
    if (currentUser?.role === 0){
        if (currentUser?.taughtClassIds < 0) {
            return (
                <div className="student-content">
                    <div>
                        <h3>Enrolled Classes</h3>
                        <div className="student-tiles">
                            <Tiles />
                        </div>
                    </div>
                </div>
            )
        } else {
            return (
                <div className="student-content">
                    <div>
                        <h3>Enrolled Classes</h3>
                        <div className="student-tiles">
                            <Tiles courseIds={currentUser?.classIds} />
                        </div>
                        <h3>Taught Classes</h3>
                        <div className="student-tiles">
                            <Tiles courseIds={currentUser?.taughtClassIds} />
                        </div>
                    </div>
                </div>
            )
        }
    }

    // if user is teacher display this
    else if (currentUser?.role === 1){
        if (currentUser?.classIds > 0){
            return (
                <div className="student-content">
                    <div>
                        <h3>Enrolled Classes</h3>
                        <div className="student-tiles">
                            <Tiles courseIds={currentUser?.classIds} />
                        </div>
                        <h3>Taught Classes</h3>
                        <div className="student-tiles">
                            <Tiles courseIds={currentUser?.taughtClassIds} />
                        </div>
                    </div>
                </div>
            )
        } else {
            return (
                <div className="student-content">
                    <div>
                        <h3>Taught Classes</h3>
                        <div className="student-tiles">
                            <Tiles courseIds={currentUser?.taughtClassIds} />
                        </div>
                    </div>
                </div>
            )
        }
    }

    // if user is institution admin display this
    else if (currentUser?.role === 2){
        return (
            <div></div>
            //<AdminContent />
        )
    }
    //// CHANGE TO 3 WHEN DONE TESTING AND REMOVE 3 BELOW
    else if (currentUser?.role === 4) {
        return (
            <div></div>
            //<AdminContent />
        )
    }

    // if user is admin display this
    else if (currentUser?.role === 3){
        return (
            <div className="student-content">
                <div>
                    <h3>Enrolled Classes</h3>
                    <div className="student-tiles">
                        <Tiles courseIds={currentUser?.classIds} />
                    </div>
                    <h3>Taught Classes</h3>
                    <div className="student-tiles">
                        <Tiles courseIds={currentUser?.taughtClassIds} />
                    </div>
                </div>
            </div>
        )
    }
    
}

export default DashboardContent;