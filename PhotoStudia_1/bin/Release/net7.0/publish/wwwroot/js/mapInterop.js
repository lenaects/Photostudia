window.mapService = {
    initMap: async function (districtData) {
        console.log("✅ initMap called with:", districtData);
        const map = L.map('ekb-map').setView([56.8389, 60.6057], 11);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; OpenStreetMap contributors'
        }).addTo(map);

        const response = await fetch('/js/ekb-districts.geojson');
        const geojson = await response.json();

        // Приводим к нижнему регистру и убираем "район"
        const priceMap = {};
        districtData.forEach(d => {
            const key = (d.district + " район").toLowerCase().trim();
            priceMap[key] = d.price;
        });

        function getColor(price) {
            if (price > 8500) return '#d73027';
            if (price > 7500) return '#fc8d59';
            if (price > 6500) return '#fee08b';
            if (price > 5500) return '#d9ef8b';
            return '#91cf60';
        }

        L.geoJSON(geojson, {
            style: function (feature) {
                const name = feature.properties.name.toLowerCase().trim();
                const price = priceMap[name] ?? 0;
                return {
                    fillColor: getColor(price),
                    weight: 2,
                    opacity: 1,
                    color: 'white',
                    dashArray: '3',
                    fillOpacity: 0.7
                };
            },
            onEachFeature: function (feature, layer) {
                const nameKey = feature.properties.name.toLowerCase().trim();
                const displayName = feature.properties.name;
                const price = priceMap[nameKey];

                if (price) {
                    layer.bindTooltip(`${displayName}: ${price} руб`, {
                        permanent: false,
                        direction: "top",
                        className: 'leaflet-tooltip-own'
                    });
                }
            }
        }).addTo(map);
        console.log("mapInterop.js загружен");
    }
};