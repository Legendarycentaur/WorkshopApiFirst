import "./App.css";
const emoji: string = ">:[";
function App() {
  return (
    <div className="min-h-screen bg-gray-50">
      <div className="max-w-7xl mx-auto px-4 py-8">
        <h1 className="text-4xl font-bold text-gray-900">Biblioteket</h1>
        <p className="text-gray-600 mt-2">
          Du har inte nångra böcker än, Väldigt dåligt bibiliotek <br />
          {emoji}
        </p>
      </div>
    </div>
  );
}

export default App;
