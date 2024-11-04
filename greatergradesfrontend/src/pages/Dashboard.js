import { useEffect, useMemo, useState } from "react";
import Header from "../components/Header";
import SideBar from "../components/SideBar";
import DashboardContent from "../components/DashboardContent";
import ProfileContent from "../components/ProfileContent";
import EnrolledClasses from "../components/EnrolledClasses";
import TaughtClasses from "../components/TaughtClasses";
import { getStorageItem } from "../functions/functions";
import { useGetUsersClasses } from "../greatergradesapi/Classes";

const Dashboard = () => {

    const [currentUser, setCurrentUser] = useState(getStorageItem('currentUser'));
    const [selectedItem, setSelectedItem] = useState('dashboard');
    const [sidebarItems, setSidebarItems] = useState([]);
    const courses = useGetUsersClasses(currentUser?.classIds)
    const assignments = useMemo(() => {
        return courses.flatMap(course => course.assignments || []);
    }, [courses])
    const assignmentNames = useMemo(() => {
        return assignments.flatMap(assignment => assignment.name || "");
    }, [assignments])

    useEffect(() => {
        const storedUser = getStorageItem('currentUser');
        setCurrentUser(storedUser);
    }, [])

    useEffect(() => {
        const newSidebarItems = [];
        console.log("in sidebar state")
        console.log(currentUser?.role)
        if (currentUser?.role === 0) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes'}
            )
        }
        else if (currentUser?.role === 1) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes'},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }
        else if (currentUser?.role === 2) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes'},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }
        else if (currentUser?.role === 3) {
            newSidebarItems.push(
                { id: 'dashboard', label: 'Dashboard'},
                { id: 'profile', label: 'Profile'},
                { id: 'enrolled classes', label: 'Enrolled Classes', assignmentLabels: assignmentNames},
                { id: 'taught classes', label: 'Taught Classes'}
            )
        }
        setSidebarItems(newSidebarItems);
    }, [currentUser, assignmentNames])

    const renderContent = () => {
        switch (selectedItem) {
            case 'dashboard':
                return <DashboardContent />;
            case 'profile':
                return <ProfileContent />;
            case 'enrolled classes':
                return <EnrolledClasses />;
            case 'taught classes':
                return <TaughtClasses />;
            default:
                return <div>doesnt match....</div>
        }
    }

    console.log(sidebarItems)



    return (
        <main className='student-dashboard'>
            <SideBar items={sidebarItems} selectedItem={selectedItem} onSelectItem={setSelectedItem} />
            <div className='student-body'>
                <Header />
                {renderContent()}
            </div>
        </main>
    );
};

export default Dashboard;