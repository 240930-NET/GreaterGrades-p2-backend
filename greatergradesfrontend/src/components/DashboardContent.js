import { useContext } from "react";
import { UserContext } from '../functions/UserContext';
import AdminContent from './AdminContent';
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

    // if user is any type of admin return this
    else if (currentUser?.role === 2 || currentUser?.role === 3){
        return (
            <AdminContent />
        )
    }
}

export default DashboardContent;