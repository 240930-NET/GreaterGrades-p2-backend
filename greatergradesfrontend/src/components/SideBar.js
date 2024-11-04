const SideBar = ({items, selectedItem, onSelectItem}) => {

    return (
        <div className="dashboard-sidebar">
            <ul>
                {items.map(item => (
                    <li key={item.id} className={`${item.id === selectedItem ? 'dashboard-sidebar-li-selected' : ''}`} onClick={() => onSelectItem(item.id)}>{item.label}
                        <ul>
                            {item.assignmentLabels?.map(assignment => (
                                <li key={assignment}>{assignment}</li>
                            ))}
                        </ul>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default SideBar;