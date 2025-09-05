package com.example.math_service.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.RequestBody;
import java.util.Map;

@RestController
@RequestMapping("/api/math")
public class MathController {

    private double getParam(Map<String, Object> body, String name, Double defaultValue) {
        if (body != null && body.containsKey(name)) {
            Object v = body.get(name);
            if (v instanceof Number) return ((Number) v).doubleValue();
            if (v instanceof String) return Double.parseDouble((String)v);
        }
        return defaultValue == null ? Double.NaN : defaultValue;
    }


    // Adição: /api/math/add
    @RequestMapping(value = "/add", method = {RequestMethod.GET, RequestMethod.POST})
    public ResponseEntity<?> add(
            @RequestParam(name = "a", required = false) Double a,
            @RequestParam(name = "b", required = false) Double b,
            @RequestBody(required = false) Map<String, Object> body
    ) {
        double x = a != null ? a : getParam(body, "a", 0.0);
        double y = b != null ? b : getParam(body, "b", 0.0);
        double result = x + y;
        return ResponseEntity.ok(Map.of("operation","add","a",x,"b",y,"result",result));
    }


    // Subtração: /api/math/sub
    @RequestMapping(value = "/sub", method = {RequestMethod.GET, RequestMethod.POST})
    public ResponseEntity<?> sub(
            @RequestParam(name = "a", required = false) Double a,
            @RequestParam(name = "b", required = false) Double b,
            @RequestBody(required = false) Map<String, Object> body
    ) {
        double x = a != null ? a : getParam(body, "a", 0.0);
        double y = b != null ? b : getParam(body, "b", 0.0);
        double result = x - y;
        return ResponseEntity.ok(Map.of("operation","sub","a",x,"b",y,"result",result));
    }


    // Multiplicação: /api/math/mul
    @RequestMapping(value = "/mul", method = {RequestMethod.GET, RequestMethod.POST})
    public ResponseEntity<?> mul(
            @RequestParam(name = "a", required = false) Double a,
            @RequestParam(name = "b", required = false) Double b,
            @RequestBody(required = false) Map<String, Object> body
    ) {
        double x = a != null ? a : getParam(body, "a", 0.0);
        double y = b != null ? b : getParam(body, "b", 0.0);
        double result = x * y;
        return ResponseEntity.ok(Map.of("operation","mul","a",x,"b",y,"result",result));
    }


    // Divisão: /api/math/div
    @RequestMapping(value = "/div", method = {RequestMethod.GET, RequestMethod.POST})
    public ResponseEntity<?> div(
            @RequestParam(name = "a", required = false) Double a,
            @RequestParam(name = "b", required = false) Double b,
            @RequestBody(required = false) Map<String, Object> body
    ) {
        double x = a != null ? a : getParam(body, "a", 0.0);
        double y = b != null ? b : getParam(body, "b", 1.0);
        if (Double.compare(y, 0.0) == 0) {
            return ResponseEntity.badRequest().body(Map.of("error","Division by zero"));
        }
        double result = x / y;
        return ResponseEntity.ok(Map.of("operation","div","a",x,"b",y,"result",result));
    }

    // Exponenciação: /api/math/pow
    @RequestMapping(value = "/pow", method = {RequestMethod.GET, RequestMethod.POST})
    public ResponseEntity<?> pow(
            @RequestParam(name = "a", required = false) Double a,
            @RequestParam(name = "b", required = false) Double b,
            @RequestBody(required = false) Map<String, Object> body
    ) {
        double x = a != null ? a : getParam(body, "a", 0.0);
        double y = b != null ? b : getParam(body, "b", 1.0);
        double result = Math.pow(x, y);
        return ResponseEntity.ok(Map.of("operation","pow","a",x,"b",y,"result",result));
    }
}