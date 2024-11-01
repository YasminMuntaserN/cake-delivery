import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from 'recharts';
import {useSales} from './hook/useSales';

function WeeklySalesChart() {
    const { data , error, isLoading } = useSales();

    if (isLoading) return <p>Loading sales data...</p>;
    if (error) return <p>Error loading sales data: {error.message}</p>;
    
    const daysOfWeek = ["Monday", 'Tuesday', "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    let SalesData ;
    if(data){
    const dataByDay = data.reduce((acc, current) => {
        acc[current.day] = current.sales;
        return acc;
    }, {});

    SalesData = daysOfWeek.map(day => ({
        day,
        sales: dataByDay[day] || 0 
    }));
    }else{
        SalesData = daysOfWeek.map(day => ({
            day,
            sales: 0 
        }));
    }
    return (
    <>    
    <h1 className="text-4xl text-basic text-center m-3 font-['Open_Sans'] font-extrabold ">This week sales</h1>
    <ResponsiveContainer width="100%" height={500} className="bg-gray-100">
    <BarChart
        data={SalesData}
        margin={{ top: 20, right: 20, left: 20, bottom: 5 }}
    >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="day" />
        <YAxis />
        <Tooltip />
        <Bar dataKey="sales" fill="#cf8999" />
    </BarChart>
</ResponsiveContainer>
</> 
);
}

export default WeeklySalesChart
