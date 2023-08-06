#include <queue>
#include <string>
#include <iostream>
using namespace std;

class Node {
public:
    int value;
    Node* parent;
    string operation;

    Node(int val, Node* p = nullptr, string op = "\0") : value(val), parent(p), operation(op) {}
};

string generate_expression(int target) {
    if (target == 1) {
        return "1"; // Base case, the target is 1.
    }

    queue<Node*> q;
    Node* root = new Node(1);
    q.push(root);

    while (!q.empty()) {
        Node* current_node = q.front();
        q.pop();

        // Try division operation
        int division_result = current_node->value / 3;
        if (division_result > 0) {
            Node* child_node = new Node(division_result, current_node, " / 3");
            if (division_result == target) {
                current_node = child_node;
                string expression = to_string(division_result);
                while (current_node->parent) {
                    expression = current_node->operation + expression;
                    current_node = current_node->parent;
                }
                return expression;
            }
            q.push(child_node);
        }

        // Try multiplication operation
        int multiplication_result = current_node->value * 2;
        Node* child_node = new Node(multiplication_result, current_node, " * 2");
        if (multiplication_result == target) {
                            current_node = child_node;
            string expression = " = " +to_string(multiplication_result);
            while (current_node->parent) {
                expression = current_node->operation + expression;
                current_node = current_node->parent;
            }
            return expression;
        }
        q.push(child_node);
    }

    return "No solution found.";
}



int main(int argc, char* argv[]) {
    if (argc != 2) {
        cout << "Error: Please provide a single non-negative integer as a command line argument." << endl;
        return 1;
    }

    int target_value;
    try {
        target_value = stoi(argv[1]);
        if (target_value < 0) {
            throw invalid_argument("");
        }
    }
    catch (invalid_argument&) {
        cout << "Error: Invalid input. Please provide a single non-negative integer as a command line argument." << endl;
        return 1;
    }

    string result = generate_expression(target_value);
    cout << "Expression: 1" <<  result <<endl;

    return 0;
}